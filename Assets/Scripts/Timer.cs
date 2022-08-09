using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timer;
    public float gameTime;
    bool stopTimer;
    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;
        timer.maxValue = gameTime;
        timer.value = gameTime;
    }

    // Update is called once per frame
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
