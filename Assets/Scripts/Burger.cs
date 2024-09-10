using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
    [SerializeField] GameObject[] stages;
    [SerializeField] GameObject indicator;
    int currentStage;
    bool onPan;



    void Start()
    {
        foreach (GameObject i in stages)
        {
            i.SetActive(false);
        }
        stages[0].SetActive(true);
        currentStage = 0;
    }

    
    void Update()
    {
        
    }

    void UpStage()
    {
        if (currentStage < stages.Length-1)
        {
            stages[currentStage].SetActive(false);
            currentStage++;
            stages[currentStage].SetActive(true);
        }
        
    }
}
