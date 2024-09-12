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

    [SerializeField] GameObject check;
    [SerializeField] GameObject x;

    Vector2 mousePos;
    Vector3 mouse;

    Pickup pickUpHover;
    DropOff dropOffHover;

    Pickup heldOrgin;

    public GameObject[] heldObject;

    int[] validDrops;
    bool hasPickup = false;

    int type;


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

        if (collision.tag == "DropOff" && hasPickup)
        {
            dropOffHover = collision.gameObject.GetComponent<DropOff>();

            if (dropOffHover.DropOffCheck(validDrops))
            {
                check.SetActive(true);
            }
            else
            {
                x.SetActive(true);
            }
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
            check.SetActive(false);
            x.SetActive(false);
        }
    }

    public void OnClickPress()
    {
        if (pickUpHover != null)
        {
            type = pickUpHover.PickupCheck();
            if (type > 0)
            {
                hasPickup = true;
                validDrops = pickUpHover.ValidDrop();
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
        check.SetActive(false);
        x.SetActive(false);
    }

}
