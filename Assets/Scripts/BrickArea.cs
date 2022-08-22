using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickArea : MonoBehaviour
{
    public BrickButton[] Childs;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void delete(int index)
    {
        Childs[index].Fade(true);
        Childs[index].Delete();
        for(int i = index+1; i < (index)+(4-index%4); i++)
        {
            Childs[i].setPositionY(Childs[i].brickPositionY()-62);
        }

    }
    public bool numContain(int number)
    {
       for(int i = 0; i < Childs.Length; i++)
        {
            if (number == Childs[i].getNumber())
                return true;
        }
        return false;
    }
    public int add( int column,int value)
    {

       
        if (numContain(value))
        {
           return -1;
        }
        for(int i = 0+column*4; i < 4+column*4; i++)
        {
            if(Childs[i].isDeleted())
            {
                Childs[i].setNumber(value);
                return 0;
            }
        }
        for(int i = 0; i < Childs.Length; i++)
        {
            if (Childs[i].isDeleted())
            {
                Childs[i].setNumber(value);
                return 0;
            }
               
        }
        return 0;
        
    }
    public void closeZero()
    {
        for (int i = 0; i < Childs.Length; i++)
        {
            if (Childs[i].getNumber() == 0)
            {
                Childs[i].transform.gameObject.SetActive(false);
            }
            else
            {
                Childs[i].transform.gameObject.SetActive(true);
                Childs[i].Fade(false);
            }
        }
    }
    public void ResPosition()
    {

        for(int i = 0; i < 4; i++)
        {
            for(int j = 1; j < 4; j++)
            {
                Childs[i * 4 + j].transform.localPosition = new Vector3( Childs[i * 4].transform.localPosition.x, Childs[i * 4].transform.localPosition.y+j*62, Childs[i * 4].transform.localPosition.z);
            }
            
        }
    }
    public int length()
    {
        return Childs.Length;
    }
    public BrickButton getChild( int index)
    {
        return Childs[index];
    }
    public void res()
    {

        for(int i = 0; i < Childs.Length; i++)
        {
            delete(i);
        }
        ResPosition();
    }
}
