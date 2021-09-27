using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class sightController : MonoBehaviour
{
    public Light2D sight;
    public Player playerScript;
    public float sightPercent, outerRadiusBase;
    private float maxBlindness, currentBlindness;

    void Start()
    {
        //converte pra uma variavel local, ja que a original é int
        maxBlindness = playerScript.maxBlindness;
    }
    void Update()
    {
        //converte pra uma variavel local, ja que a original é int
        currentBlindness = playerScript.currentBlindness;
        //primeiro descobre a porcentagem da visão atual em relação ao maximo
        sightPercent = (currentBlindness / maxBlindness);
        sight.pointLightOuterRadius = outerRadiusBase * sightPercent;
        Debug.Log(sightPercent);
    }
}
