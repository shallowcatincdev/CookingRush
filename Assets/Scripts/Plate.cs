using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] GameObject bun;


    bool hasBun = false;

    // Start is called before the first frame update
    void Start()
    {
        bun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int AddBun()
    {
        bun.SetActive(true);
        hasBun = true;
        return 12;

    }
}
