using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] List<int> dropCodes;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] int type;
    [SerializeField] bool hasDropoff;
    [SerializeField] List<GameObject> dropoffItems;
    [SerializeField] List<int> dropoffTypes;
    [SerializeField] DropOff dropoff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int PickupCheck()
    {
        return type;


    }

    public void Link(GameObject obj, int objtype)
    {
        dropoffItems.Add(obj);
        dropoffTypes.Add(objtype);
        Debug.Log("LINK");
        foreach (int i in dropoffTypes)
        {
            Debug.Log(i);
        }
        type = objtype;

        if (dropoffTypes.Contains(1) && dropoffTypes.Contains(11) && dropoffTypes.Count == 2)
        {
            type = 13;
        }

        if (obj.name == "BunPrefab(Clone)")
        {
            dropCodes.Add(11);
        }
        else if (obj.name == "PanPrefab(Clone)")
        {
            dropCodes.Add(1);
        }
        else if (obj.name == "BurgerPrefab(Clone)")
        {
            dropCodes.Add(2);
            dropCodes.Add(12);
        }
    }

    public bool CanReturn()
    {
        return hasDropoff;
    }

    public DropOff getDropoff()
    {
        return dropoff;
    }

    public int[] ValidDrop()
    {
        return dropCodes.ToArray();
    }

    public GameObject[] SpawnObject()
    {
        if (!hasDropoff)
        {
            GameObject obj = Instantiate(itemPrefab, transform);

            return new GameObject[]{obj};
        }
        else
        {
            if(type == 13)
            {
                dropoffItems[1].GetComponent<Burger>().OnPan(false);
                dropoff.DropCode(1);
            }


            var temp = dropoffItems.ToArray();

            dropoffItems.Clear();
            dropoffTypes.Clear();
            dropCodes.Clear();

            return temp;
        }
    }
}
