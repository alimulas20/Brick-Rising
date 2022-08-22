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
            stopTimer = true;

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
    }
    public void resTime()
    {
        timeCount = gameTime + Time.time;
        stopTimer = false;
    }
}
