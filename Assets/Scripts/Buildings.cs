using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Buildings : MonoBehaviour
{
  
    Vector2 startAnc;
    // Start is called before the first frame update
    void Start()
    {
        startAnc= GetComponent<RectTransform>().anchorMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void increase()
    {
        Vector2 temp = GetComponent<RectTransform>().anchorMax;
        temp.y += 0.05f;
        GetComponent<RectTransform>().DOAnchorMax(temp,0.5f).SetEase(Ease.InBounce).SetAutoKill();
    }
    public float getAnc()
    {
       
        return GetComponent<RectTransform>().anchorMax.y;
    }
    public void ancRes()
    {
        GetComponent<RectTransform>().DOAnchorMax(startAnc,0.5f).SetEase(Ease.InBounce).SetAutoKill();
    }
}
