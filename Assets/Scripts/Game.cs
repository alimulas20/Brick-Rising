using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    //public Button brickButton;
    //public Image BrickPanels;
    public GridLayoutGroup brickButton;
    public GridLayoutGroup bottomPanel;
    public GridLayoutGroup topPanel;

    
    Button[] brickBut;
    Image[] bottom;
    Image[] top;

    Text[] BrickText;

    int level;
    bool picker;
    // Start is called before the first frame update
    void Start()
    {
        brickBut = brickButton.GetComponents<Button>();
        bottom = bottomPanel.GetComponents<Image>();
        top = topPanel.GetComponents<Image>();
        BrickText = new Text[brickBut.Length];
        picker = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator numberGenerator()
    {
        for(int i = 0; i < brickBut.Length; i++)
        {
            
            
        }
        yield return new WaitWhile(() => !picker);
        picker = false;
    }

}
