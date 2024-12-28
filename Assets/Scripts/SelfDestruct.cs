using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private float totalTime;

    void Awake()
    {
        totalTime = 10.0f;
    }
    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        if (totalTime > 0)
        {
            //Subtract elapsed time every frame
            totalTime -= Time.deltaTime;
        }

        else
        {
            gameObject.SetActive(false);
            totalTime = 10.0f;
        }
    }
}
