using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour
{
    [SerializeField] int dropCode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        obj.transform.position = transform.position;

        if (type == 1 && dropCode == 1)
        {
            dropCode = 2;
        }


        if (type == 11 && dropCode == 2)
        {
            dropCode = 3;
            obj.GetComponent<Burger>().OnPan(true);
        }

        if (type == 12)
        {
            Destroy(obj);
            dropCode = this.GetComponentInChildren<Plate>().AddBun();
        }
    }

}
