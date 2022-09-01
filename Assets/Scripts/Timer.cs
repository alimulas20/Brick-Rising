using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timer;
    public float gameTime;
    public bool stopTimer;
    float timeCount = 0;
    bool started;
   


    void Start()
    {
        stopTimer = false;
        timer.maxValue = gameTime;
        timer.value = gameTime;
        timeCount = gameTime;
        
    }
    void Update()
    {
        float time = timeCount - Time.time;
        if (time <= 0)
        {
            if (started)
            {
                stopTimer = true;
                started = false;
            }
            

        }
        if (stopTimer == false)
        {
            timer.value = time;
        }
    }
    public void play()
    {
        timeCount = gameTime;
        timeCount += Time.time;
        started = true;
    }
    public void resTime()
    {
        timeCount = gameTime + Time.time;
        stopTimer = false;
        started = true;
    }
}
