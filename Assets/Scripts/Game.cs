using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public BrickArea brickButton;
    public Panel bottomPanel;
    public Panel topPanel;
    public Text levelText;
    public BackPanel buildings;

    int level;
    int [] levelBricks= { 3,3,4,5,6,7,8,9,10,11,12, 13,14,15,16 };
    int [] levelMaxNumber= {9,15,25,35,45,55,65,75,85,95,105,115,135,145,165};
    int max;
    int delCount;
    // Start is called before the first frame update
    void Start()
    {
       
        level = 0;
        deleteBrick();
        StartCoroutine(numberGenerator());
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
            i += brickButton.add(Random.Range(0, 4), Random.Range(1, levelMaxNumber[level]));
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
            addBrick();
            if (levelBricks[level] == delCount)
            {
                delCount = 0;
                level++;
                deleteBrick();
                buildings.incAnc();
                StartCoroutine(numberGenerator());
            }
        }

    }
    void deleteBrick()
    {
        topPanel.regen();
        bottomPanel.regen();
        for (int i = 0; i < levelBricks[level]; i++)
        {
            int number = Random.Range(0, 16);
            if (bottomPanel.isEmpty())
            {
                number = Random.Range(0, 8);
            }
            if (topPanel.isEmpty())
            {
                number = Random.Range(8, 16);
            }
            bool deleted = false;
            while (!deleted)
            {
                if (number > 7)
                {
                    if(!topPanel.isDeleted(number % 8))
                    {
                        topPanel.delete(number % 8);
                        deleted = true;
                    }
                    else
                    {
                        number++;
                    }
                }
                else
                {
                    if (!bottomPanel.isDeleted(number % 8))
                    {
                        bottomPanel.delete(number % 8);
                        deleted = true;
                    }
                    else
                    {
                        number++;
                    }
                }
            }
        }
        
       
    }
    void addBrick()
    {
        if (bottomPanel.isMissing() != -1)
        {
            bottomPanel.comeback(bottomPanel.isMissing());
        }
        else if(topPanel.isMissing()!=-1)
        {
            topPanel.comeback(topPanel.isMissing());
        }
    }
}
