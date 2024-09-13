using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] GameObject bun;
    [SerializeField] GameObject buttons;
    [SerializeField] DropOff dropoff;

    List<GameObject> plateHolds;
    List<int> typesHolds;

    GameObject burger;

    // Start is called before the first frame update
    void Start()
    {
        bun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendOrder()
    {
        buttons.SetActive(false);
    }

    public void TrashOrder()
    {
        plateHolds = dropoff.PlateThing();
        foreach (GameObject i in plateHolds)
        {
            Destroy(i);
        }

        plateHolds.Clear();
        buttons.SetActive(false);
    }

    public int AddBun()
    {



        buttons.SetActive(true);

        
        bun.SetActive(true);
        return 12;
        
        
    }


}
