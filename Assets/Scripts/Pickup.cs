using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] int[] dropCodes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool PickupCheck()
    {
        return true;
    }

    public int[] ValidDrop()
    {
        return dropCodes;
    }
}
