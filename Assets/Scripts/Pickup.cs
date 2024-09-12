using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] int[] dropCodes;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] int type;

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

    public int[] ValidDrop()
    {
        return dropCodes;
    }

    public GameObject SpawnObject()
    {
        GameObject obj = Instantiate(itemPrefab, transform);

        return obj;
    }
}
