using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlindnessBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxBlindness(int blindness)
    {
        slider.maxValue = blindness;
        slider.value = blindness;
    }


    public void SetBlindness(int blindness)
    {
        slider.value = blindness;
    }
}
