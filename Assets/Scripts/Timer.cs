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
    float penalty;
   


    void Start()
    {
        stopTimer = false;
        timer.maxValue = gameTime;
        timer.value = gameTime;
        timeCount = gameTime;
        
    }
    void Update()
    {
        float time = timeCount-penalty - Time.time;
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
        penalty = 0;
        timeCount = gameTime;
        timeCount += Time.time;
        started = true;
    }
    public void resTime()
    {
        penalty = 0;
        timeCount = gameTime + Time.time;
        stopTimer = false;
        started = true;
    }
    public void decTime()
    {
        penalty += 2;
    }
}
