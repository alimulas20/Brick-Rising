using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    //public Button brickButton;
    //public Image BrickPanels;
    public BrickArea brickButton;
    public GridLayoutGroup bottomPanel;
    public GridLayoutGroup topPanel;
    public Text levelText;

    
    


    Image[] bottom;
    Image[] top;

    Text[] BrickText;

    int level;
    int [] levelBricks= { 3,3,4,5,6,7,8,9,10,11,12, 13,14,15,16 };
    int [] levelMaxNumber= {9,15,25,35,45,55,65,75,85,95,105,115,135,145,165 };
    int max;
    int delCount;
    Vector2[] location;
    // Start is called before the first frame update
    void Start()
    {
       
        level = 0;
        /*bottom = bottomPanel.GetComponents<Image>();
        top = topPanel.GetComponents<Image>();
        BrickText = new Text[brickBut.Length];*/
        StartCoroutine( numberGenerator());
        brickButton.closeZero();
        max = 0;
        delCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = (level + 1).ToString();
        for (int i = 0; i < brickButton.length(); i++)
        {
            if (brickButton.getChild(i).getNumber() > max)
            {
                if (!brickButton.getChild(i).isDeleted())
                    max = brickButton.getChild(i).getNumber();
            }
        }
        if(levelBricks[level]==delCount)
        {
            System.GC.Collect();
            Resources.UnloadUnusedAssets();
            delCount = 0;
            level++;
            StartCoroutine(numberGenerator());
           
        }
    }
    IEnumerator numberGenerator()
    {
        if (level != 0)
        {
            yield return new WaitForSeconds(1f);
            brickButton.ResPosition();
        }
        for (int i = 0; i < levelBricks[level]; i++)
        {
            int column =Random.Range(0, 4);
            int number = Random.Range(1, levelMaxNumber[level]);
            
            if (!brickButton.numContain(number))
                brickButton.add(column, number);
            else
                i--;
        }
        
        brickButton.closeZero();



    }
    public void pick(int index)
    {
        if (brickButton.getChild(index).getNumber() == max)
        {
            brickButton.delete(index);
            max = 0;
            delCount++;
        }

    }
    public void resPos()
    {
        for(int i = 0; i < location.Length; i++)
        {
            brickButton.getChild(i).setPositionY((int)location[i].y,1);
        }
    }
}
