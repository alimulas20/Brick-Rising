using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class BrickButton : MonoBehaviour
{
    public Text numberText;
    bool Deleted;

    // Start is called before the first frame update
    void Start()
    {
        Deleted = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<Image>().color.a == 0)
        {
            numberText.text = "0";
            transform.gameObject.SetActive(false);
        }
    }

    public void setNumber( int number )  {
        numberText.text = number.ToString();
        Deleted = false;
    }
    public int getNumber()
    {
        return int.Parse(numberText.text);
    }
    public int brickPositionX()
    {
        return (int)transform.localPosition.x;
    }
    public int brickPositionY()
    {
        return (int)transform.localPosition.y;
    }
    public void Fade(bool isOut)
    {
        if (isOut)
        {
            transform.GetComponent<Image>().DOFade(0, 0.5f).SetAutoKill();
             numberText.DOFade(0, 1f).SetAutoKill();
           /* Color a = transform.GetComponent<Image>().color;
            a.a = 0;
            transform.GetComponent<Image>().color = a;
            Color b = numberText.color;
            b.a = 0;
            numberText.color = b;*/
        }
        else
        {
            transform.GetComponent<Image>().DOFade(1, 0.5f).SetAutoKill();
            numberText.DOFade(1, 1f).SetAutoKill();
           /* Color a = transform.GetComponent<Image>().color;
            a.a = 1;
            transform.GetComponent<Image>().color = a;
            Color b = numberText.color;
            b.a = 1;
            numberText.color = b;*/
            
        }
    }
    public void setPositionY(int y)
    {
        transform.DOLocalMoveY(y, 0.5f).SetEase(Ease.InExpo).SetAutoKill();
       // transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
    }
    public void Delete()
    {
        Deleted = true;
    }
    public bool isDeleted()
    {
        return Deleted;
    }
    
}
