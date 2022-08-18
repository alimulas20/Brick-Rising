using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Panel : MonoBehaviour
{
    public Brick[] bricks;

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
        bricks[index].delete();
    }
    public void regen()
    {
        for(int i = 0; i < bricks.Length; i++)
        {
            bricks[i].regen();

        }
    }
    public bool isDeleted(int index)
    {
       return bricks[index].isDeleted();
        
    }
    public int isMissing()
    {

        for(int i = 0; i < bricks.Length; i++)
        {
            
           
            if (bricks[i].isDeleted())
            {
                return i;
            }
        }
        return -1;
    }
    public void comeback(int index)
    {
        bricks[index].regen();
    }
    public bool isEmpty()
    {
        for(int i = 0; i < bricks.Length; i++)
        {
            if (!bricks[i].isDeleted())
            {
                return false;
            }
        }
        return true;
    }
}
