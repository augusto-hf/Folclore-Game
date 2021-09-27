using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class sightController : MonoBehaviour
{
    public Light2D sight;
    public Player playerScript;
    public float sightPercent;

    void Update()
    {
        //primeiro descobre a porcentagem da visão atual em relação ao maximo
        sightPercent = (playerScript.currentBlindness / playerScript.maxBlindness);
        sight.pointLightOuterRadius = 8 * sightPercent;
        Debug.Log(sightPercent);
    }
}
