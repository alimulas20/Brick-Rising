using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Panel : MonoBehaviour
{
    public Image[] images;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void delete(int index)
    {
        /*Color color = images[index].color;
        color.a = 0;
        images[index].color = color;*/
        images[index].DOFade(0, 0.75f);
    }
    public void regen()
    {
        for(int i = 0; i < images.Length; i++)
        {
            Color color = images[i].color;
            color.a = 1;
            images[i].color = color;

        }
    }
    public bool isDeleted(int index)
    {
        if (images[index].color.a == 0)
        {
            return true;
        }
        return false;
    }
    public int isMissing()
    {
        for(int i = 0; i < images.Length; i++)
        {
            if (images[i].color.a == 0)
            {
                return i;
            }
        }
        return -1;
    }
    public void comeback(int index)
    {
        Color a= images[index].color;
        a.a = 1;
        images[index].color = a;
    }
    public bool isEmpty()
    {
        for(int i = 0; i < images.Length; i++)
        {
            if (!isDeleted(i))
            {
                return false;
            }
        }
        return true;
    }
}
