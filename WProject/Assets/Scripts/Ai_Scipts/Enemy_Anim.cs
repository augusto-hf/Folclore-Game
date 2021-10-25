using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Anim : MonoBehaviour
{
    public Animator anim;
    public Transform Pos;
    public float Zvaule;
    float i,x;

    void Update()
    {
        Debug.Log("1");
        Zvaule = Pos.eulerAngles.z;

        if (Zvaule >= 90 && Zvaule < 180)
        {
            Debug.Log("1");
            i = 0;
            x = 0;
        }
        else if (Zvaule >= 180 && Zvaule < 270)
        {
            Debug.Log("2");
            i = -1;
            x = 0;


        }
        else if (Zvaule >= 270 && Zvaule < 360)
        {
            Debug.Log("3");
            i = 1;
            x = 0;


        }
        else if (Zvaule >= 0 && Zvaule < 90)
        {
            Debug.Log("4");
            i = 0;
            x = -1;


        }

        anim.SetFloat("Horizontal", i);
        anim.SetFloat("Vertical", x);
        //anim.SetFloat("Speed", movement.sqrMagnitude);
    }
}
