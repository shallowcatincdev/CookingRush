using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
    [SerializeField] GameObject[] stages;
    [SerializeField] GameObject[] indicator;
    int currentStage;
    bool onPan;

    int cookTime;

    int indnum;


    void Start()
    {
        foreach (GameObject i in stages)
        {
            i.SetActive(false);
        }
        stages[0].SetActive(true);
        currentStage = 0;
    }

    
    void FixedUpdate()
    {
        if (onPan)
        {
            foreach (GameObject i in indicator)
            {
                i.SetActive(false);
            }
            cookTime++;
            indicator[indnum].SetActive(true);

            if (cookTime >= 400)
            {
                cookTime = 0;
                UpStage();
            }

        }
        else
        {
            foreach (GameObject i in indicator)
            {
                i.SetActive(false);
            }
        }


    }

    public void OnPan(bool value)
    {
        onPan = value;
    }

    void UpStage()
    {
        if (currentStage < stages.Length-1)
        {
            stages[currentStage].SetActive(false);
            currentStage++;
            stages[currentStage].SetActive(true);
            if (onPan)
            {
                if (currentStage < 3)
                {
                    indnum = 0;
                }
                if (currentStage == 3)
                {
                    indnum = 1;
                }
                if (currentStage == 4)
                {
                    indnum = 2;
                }
                if (currentStage == 5)
                {
                    indnum = 3;
                }
                if (currentStage > 5)
                {
                    indnum = 4;
                }

                foreach (GameObject i in indicator)
                {
                    i.SetActive(false);
                }

                indicator[indnum].SetActive(true);
            }
        }
        
    }
}
