using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Brick : MonoBehaviour
{
    bool deleted;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        deleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void delete()
    {
        //image.DOFade(0, 0.75f).SetAutoKill(false);
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
    }
}