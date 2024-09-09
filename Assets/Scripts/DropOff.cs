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
}
