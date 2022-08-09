using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timer;
    public float gameTime;
    bool stopTimer;
   
    void Start()
    {
        stopTimer = false;
        timer.maxValue = gameTime;
        timer.value = gameTime;
    }
    void Update()
    {
        float time = gameTime - Time.time;
        
        if (time <= 0)
        {
            stopTimer = true;
        }
        if (stopTimer == false)
        {
            timer.value = time;
        }
    }
}
