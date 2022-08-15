using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class BrickButton : MonoBehaviour
{
    float positionFirst;
    public Text numberText;
    bool Deleted;

    // Start is called before the first frame update
    void Start()
    {
        positionFirst = transform.localPosition.y;
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
            transform.GetComponent<Image>().DOFade(0, 1f).SetAutoKill();
            numberText.DOFade(0, 1f).SetAutoKill();
        }
        else
        {
            transform.GetComponent<Image>().DOFade(1, 1f).SetAutoKill();
            numberText.DOFade(1, 1f);
        }
    }
    public void setPositionY(int y,int time)
    {
        transform.DOLocalMoveY(y, time).SetEase(Ease.InExpo).SetAutoKill();
        //transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
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
