using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] GameObject bun;
    [SerializeField] GameObject buttons;

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
        foreach (GameObject i in plateHolds)
        {
            Destroy(i);
        }
        burger.SetActive(false);
        burger = null;

        plateHolds.Clear();
        buttons.SetActive(false);
    }

    public int AddBun(GameObject obj, int type)
    {


        Debug.Log(obj.name);

        buttons.SetActive(true);

        if (type == 12)
        {
            bun.SetActive(true);
            return 12;
        }
        else if (type == 13 && !typesHolds.Contains(14))
        {
            plateHolds.Add(obj);
            return 23;
        }
        else if (type == 14 && !typesHolds.Contains(13))
        {
            plateHolds.Add(obj);
            return 24;
        }
        else if (type == 11)
        {
            burger = obj;
            return 22;
        }
        else
        {
            plateHolds.Add(obj);
            return 25;
        }
        
    }


}
