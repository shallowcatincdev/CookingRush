using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropOff : MonoBehaviour
{
    [SerializeField] int dropCode;
    [SerializeField] bool hasPickup;
    [SerializeField] Pickup pickup;

    GameObject[] dropedObjects;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropCode(int Code)
    {
        dropCode = Code;
    }

    public bool DropOffCheck(int[] codes)
    {
        foreach (int code in codes)
        {
            if (code == dropCode)
            {
                return true;
            }
        }

        return false;
    }

    public void Transfer(GameObject obj, int type)
    {
        if (type == 99 || type == 13)
        {
            string objname = obj.name;

            if (objname == "BunPrefab(Clone)")
            {
                type = 12;
                
            }
            else if (objname == "PanPrefab(Clone)")
            {
                type = 1;
            }
            else if (objname == "BurgerPrefab(Clone)")
            {
                type = 11;
            }
        }

        
        
        

        obj.transform.position = transform.position;

        if (type == 1 && dropCode == 12)
        {
            if (obj.name == "PanPrefab(Clone)")
            {
                Destroy(obj);
            }

        }

        if (type == 1 && dropCode == 1)
        {
            dropCode = 2;
        }


        if (type == 11 && dropCode == 2)
        {
            dropCode = 3;
            obj.GetComponent<Burger>().OnPan(true);
        }

        if (type == 11 && dropCode == 12)
        {
            dropCode = 22;
        }

        if (type == 12)
        {
            Destroy(obj);
            dropCode = this.GetComponentInChildren<Plate>().AddBun();
        }

        if (hasPickup)
        {
            pickup.Link(obj, type);
        }
    }

}
