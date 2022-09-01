using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPanel : MonoBehaviour
{
    public Buildings [] buildings;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void incAnc()
    {
        int number=Random.Range(4, 6);
        if (buildings[number].getAnc() < 0.85)
        {
            buildings[number].increase();
        }
        else
        {
            for(int i = 4; i < 6; i++)
            {
                if(buildings[(number + i) % 6].getAnc() < 0.95)
                {
                    buildings[(number + i) % 6].increase();
                }
            }
           
        }
    }
}
