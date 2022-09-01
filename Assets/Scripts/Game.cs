using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Game : MonoBehaviour
{
    public BrickArea brickButton;
    public Panel[] panels;
    public BackPanel buildings;
    public GameObject panel;
    public GameObject bg;
    public Timer slider;
    public Image toolPanel;
    public Image intro;
    public Image introButton;
    public Image win;
    public Image lose;
    public Finish finishObject;

    bool play;
    int level;
    int [] levelBricks= { 3,3,4,5,6,7,8,9,10,11,12, 13,14,15,16 };
    int [] levelMaxNumber= {9,15,25,35,45,55,65,75,85,95,105,115,135,145,165};
    int max;
    int maxIndex;
    int delCount;
    bool clueBool;
    float clueStarter;
    bool finish;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        play = false;
        StartCoroutine(starter());
        level = 0;
        deleteBrick();
        StartCoroutine(numberGenerator());
        brickButton.closeZero();
        max = 0;
        delCount = 0;
        maxIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finish)
        {
            //levelText.text = (level + 1).ToString();
            for (int i = 0; i < brickButton.length(); i++)
            {
                if (brickButton.getChild(i).getNumber() > max)
                {
                    if (!brickButton.getChild(i).isDeleted())
                    {
                        max = brickButton.getChild(i).getNumber();
                        maxIndex = i;
                    }

                }
            }
            if (intro.color.a == 0)
            {
                intro.gameObject.SetActive(false);
                introButton.gameObject.SetActive(false);
            }
            if (slider.stopTimer == true)
            {
                finish = true;
                //slider.resTime();
                lose.gameObject.SetActive(true);
                StartCoroutine(finisher());
                /*
                brickButton.res();
                max = 0;
                brickButton.ResPosition();
                bottomPanel.regen();
                topPanel.regen();
                StartCoroutine(numberGenerator());*/

            }
        }
       
 
    }
    IEnumerator starter()
    {
        yield return new WaitForSeconds(.5f);
        introButton.gameObject.SetActive(true);
        introButton.DOFade(1, 0.5f);
        yield return new WaitWhile(()=>!play);
        clueStarter = Time.time;
        brickButton.gameObject.SetActive(true);
        panel.SetActive(true);
        bg.SetActive(true);
        toolPanel.gameObject.SetActive(true);
        slider.gameObject.SetActive(true);
        slider.play();
        intro.DOFade(0, 0.5f);
        introButton.DOFade(0, 0.5f);


    }
    IEnumerator finisher()
    {
        slider.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        finishObject.setScore(score);
        score = 0;
        level = 0;
        lose.gameObject.SetActive(false);
        for (int i = 0; i < panels.Length; i++)
            panels[i].fadeOut();
        toolPanel.DOFade(0, .5f);
        brickButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(.5f);
        toolPanel.gameObject.SetActive(false);
      
        
    }
    public void StartPlay()
    {
        play = true;


    }
    IEnumerator clue(int clueTime)
    {

        if (!clueBool)
        {
            clueBool = true;
            clueStarter = Time.time;
            yield return new WaitWhile(() => (Time.time < clueStarter + clueTime));
            brickButton.getChild(maxIndex).clue();
            yield return new WaitWhile(() => Time.time < clueStarter + 1.1*clueTime);
            clueBool = false;
        }
       
      
    }

    IEnumerator numberGenerator()
    {
        delCount = 0;
        // if (level != 0)
        if (level < 5)
            StartCoroutine(clue(5));

        yield return new WaitForSeconds(1f);
        deleteBrick();
        win.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        brickButton.ResPosition();
         
        
        for (int i = 0; i < levelBricks[level]; i++)    
        {
            i += brickButton.add(Random.Range(0, 4), Random.Range(1, levelMaxNumber[level]));
        }
       
        brickButton.closeZero();
    }
    public void pick(int index)
    {
        if (level < 5)
            StartCoroutine(clue(4));
        //brickButton.killWrong();
        if (brickButton.getChild(index).getNumber() == max)
        {
           
            clueStarter = Time.time;
            addBrick(max,brickButton.getChild(index).getPosition());
            brickButton.delete(index);
            brickButton.getChild(maxIndex).killClue();
            maxIndex = -1;
            max = 0;
            delCount++;
            
            if (levelBricks[level] == delCount)
            {
                win.gameObject.SetActive(true);
                delCount = 0;
                level++;
                //deleteBrick();
                buildings.incAnc();
                score += (level + 1) * 111;
                if (level < 15)
                {
                    slider.play();
                    StartCoroutine(numberGenerator());
                }

            }
        }
        else
        {
            if(!brickButton.getChild(index).isDeleted())
                brickButton.getChild(index).wrong();
           
        }

    }
    void deleteBrick()
    {
       for(int i = 0; i < panels.Length; i++)
        {
            panels[i].regen();
        }
        for (int i = 0; i < levelBricks[level]; i++)
        {
            int number = Random.Range(0, 16); 
            bool deleted = false;
            while (!deleted)
            {
                if (number > 9)
                {
                    if(!panels[2].isDeleted(number-9))
                    {
                        panels[2].delete(number-9);
                        deleted = true;
                    }
                    else
                    {
                        number++;
                    }
                }
                else if(number>3)
                {
                    if (!panels[1].isDeleted(number - 3))
                    {
                        panels[1].delete(number -3);
                        deleted = true;
                    }
                    else
                    {
                        number++;
                    }
                }
                else
                {
                    if (!panels[0].isDeleted(number+2))
                    {
                        panels[0].delete(number+2);
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
    void addBrick( int value,Vector3 position)
    {
        for(int i = 0; i < panels.Length; i++)
        {
            if (panels[i].isMissing() != -1)
            {
                panels[i].comeback(panels[i].isMissing(), value, position);
                break;
            }
        }
       
    }
    public void restart()
    {
        slider.gameObject.SetActive(true);
        toolPanel.gameObject.SetActive(true);
        for(int i = 0; i < panels.Length; i++)
        {
            panels[i].fadeIn();
            panels[i].regen();
        }
        brickButton.gameObject.SetActive(true);
        toolPanel.DOFade(1, .5f);
        brickButton.res();
        brickButton.ResPosition();
        finish = false;
        slider.resTime();
        StartCoroutine(numberGenerator());
        max = 0;
    }
}
