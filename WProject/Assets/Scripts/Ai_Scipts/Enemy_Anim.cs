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
        Zvaule = Pos.eulerAngles.z;
        if (Zvaule >= 90 && Zvaule < 135)
        {
            i = 0;
            x = 1;
        }
        if (Zvaule >= 45 && Zvaule < 65)
        {
            i = 1;
            x = 1;
        }
        if (Zvaule >= 65 && Zvaule < 90)
        {
            i = -1;
            x = 0;
        }
        else if (Zvaule >= 91 && Zvaule < 140)
        {
          i = -1;
          x = -1;


        }
        else if (Zvaule >= 180 && Zvaule < 225)
        {
            i = 0;
            x = 1;


        }
        else if (Zvaule >= 225 && Zvaule < 270)
        {
            i = 1;
            x = -1;


        }
        else if (Zvaule >= 270 && Zvaule < 315)
        {
            i = 1;
            x = 0;


        }
        else if (Zvaule >= 315 && Zvaule < 350)
        {
            i = -1;
            x = 1;


        }
        else if (Zvaule >= 0 && Zvaule < 45 || Zvaule > 350)
        {
            i = 0;
            x = -1;


        }

        anim.SetFloat("Horizontal", i);
        anim.SetFloat("Vertical", x);
        anim.SetFloat("Vel", 1f);
    }
}
