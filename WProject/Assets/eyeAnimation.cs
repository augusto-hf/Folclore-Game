using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eyeAnimation : BlindnessBar
{

    [Header("Eye Animation")]
    public Image imageRendererEye;
    public Sprite[] spriteArrayEye;

    public Player player;
    private float currentBlindness, maxBlindness, value;

    // Start is called before the first frame update
    void Start()
    {
        imageRendererEye.sprite = spriteArrayEye[5];
    }

    // Update is called once per frame
    void Update()
    {

        currentBlindness = player.currentBlindness;
        maxBlindness = player.maxBlindness;

        value = currentBlindness / maxBlindness;

        if (value > 0.8 && value <= 1.0)
        {
            imageRendererEye.sprite = spriteArrayEye[5];
        }
        else if (value <= 0.8 && value > 0.6)
        {
            imageRendererEye.sprite = spriteArrayEye[4];
        }
        else if (value <= 0.6 && value > 0.4)
        {
            imageRendererEye.sprite = spriteArrayEye[3];
        }
        else if (value <= 0.4 && value > 0.2)
        {
            imageRendererEye.sprite = spriteArrayEye[2];
        }
        else if(value <= 0.2 && value > 0)
        {
            imageRendererEye.sprite = spriteArrayEye[1];
        }
        else
        {
            imageRendererEye.sprite = spriteArrayEye[0];
        }
    }


}
