using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class Cursor : MonoBehaviour
{
    PlayerInput playerInput;
    [SerializeField] Camera cam;
    Vector2 mousePos;
    Vector3 mouse;

    Pickup pickUpHover;
    DropOff dropOffHover;

    Pickup heldOrgin;

    public GameObject[] heldObject;

    int[] validDrops;
    bool hasPickup = false;

    int type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePos = cam.ScreenToWorldPoint(mouse);
        mousePos.x += 0.25f;
        mousePos.y -= 0.25f;
        transform.position = mousePos;
        if (hasPickup)
        {
            foreach (GameObject i in heldObject)
            {
                i.transform.position = mousePos;
            }
            
        }
    }

    public void OnMouse(InputValue value)
    {
        mouse = value.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pickup")
        {
            pickUpHover = collision.gameObject.GetComponent<Pickup>();
        }

        if (collision.tag == "DropOff")
        {
            dropOffHover = collision.gameObject.GetComponent<DropOff>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Pickup")
        {
            pickUpHover = null;
        }

        if (collision.tag == "DropOff")
        {
            dropOffHover = null;
        }
    }

    public void OnClickPress()
    {
        if (pickUpHover != null)
        {
            Debug.Log("PICKUP NOT NULL");
            type = pickUpHover.PickupCheck();
            if (type > 0)
            {
                hasPickup = true;
                validDrops = pickUpHover.ValidDrop();
                Debug.Log("PICKUP");
                heldOrgin = pickUpHover;
                heldObject = pickUpHover.SpawnObject();
            }
        }
        
    }

    public void OnClickRelease()
    {
        if (hasPickup && dropOffHover != null)
        {
            if (dropOffHover.DropOffCheck(validDrops))
            {
                foreach (GameObject i in heldObject)
                {
                    dropOffHover.Transfer(i, type);
                }
                
                Debug.Log("DROPOff");
            }
            else
            {
                if (!heldOrgin.CanReturn())
                {
                    foreach (GameObject i in heldObject)
                    {
                        Destroy(i);
                    }
                }
                else
                {
                    DropOff drop = heldOrgin.getDropoff();
                    foreach (GameObject i in heldObject)
                    {
                        drop.Transfer(i, 99);
                    }
                    
                }
                
            }
            
        }
        
        if (dropOffHover == null && heldOrgin != null)
        {
            if (heldOrgin.CanReturn())
            {
                DropOff drop = heldOrgin.getDropoff();
                foreach (GameObject i in heldObject)
                {
                    drop.Transfer(i, 99);
                }
            }
            else
            {
                foreach (GameObject i in heldObject)
                {
                    Destroy(i);
                }
                
            }
        }
        hasPickup = false;
        heldOrgin = null;
        type = 0;
    }

}
