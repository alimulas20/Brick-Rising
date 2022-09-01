using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public Image Score;
    public Text ScoreText;
    public Image Restart;
    public Text RestartText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setScore(int score)
    {
        ScoreText.text = "Score:     " + score;
    }
}
