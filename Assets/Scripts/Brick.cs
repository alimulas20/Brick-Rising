using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Brick : MonoBehaviour
{
    bool deleted;
    private Image image;
    public Text text;
    Vector2 origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.localPosition;
        image = GetComponent<Image>();
        deleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (GetComponent<Image>().color.a == 0)
        {
            deleted = true;
        }*/
    }
    public void delete()
    {
       
        Color a = GetComponent<Image>().color;
        a.a = 0;
        GetComponent<Image>().color = a;
        deleted = true;
    }
    public bool isDeleted()
    {
        return deleted;
    }
    public void regen()
    {
        Color a= GetComponent<Image>().color;
        a.a = 1;
        GetComponent<Image>().color = a;
        deleted = false;
        text.text = "";
    }
    public void setText(string  value)
    {
        text.text = value;
    }
    public void setText(int value)
    {
        text.text = value.ToString();
    }
    public void comeback(int value,Vector3 position)
    {
        deleted = false;
        setText(value);
        //transform.localPosition = new Vector3(500, -100);
        transform.localPosition = position;
        Sequence comeb = DOTween.Sequence();
        Vector3 []path = new Vector3[2];
        transform.SetAsLastSibling();
        /*path[0] = new Vector3(300, -100, 0);
        path[1] = origin;
        comeb.Append(transform.DOLocalPath(path,1f,PathType.CatmullRom));*/
        comeb.Append(transform.DOLocalJump(origin, 1f, 2, 1f, true));
        comeb.Join(image.DOFade(1, .5f));
        //comeback.Join(image.rectTransform.DOSizeDelta(new Vector2(110, 50), 0.5f));
        comeb.Join(text.DOFade(1, 1f));
        
        //image.rectTransform.sizeDelta = new Vector2(200, 100);
        
        
    }
    public void fadeOut()
    {
        GetComponent<Image>().DOFade(0, 0.5f).SetAutoKill();
        text.DOFade(0, 0.5f).SetAutoKill();
    }
    public void fadeIn()
    {
        GetComponent<Image>().DOFade(1, 0.5f).SetAutoKill();
        text.DOFade(1, 0.5f).SetAutoKill().SetAutoKill();
    }
}
