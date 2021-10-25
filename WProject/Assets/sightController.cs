using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class sightController : MonoBehaviour
{
    public Light2D sight;
    public Player playerScript;
    public float currentSightPercent, targetSightPercent, outerRadiusBase;
    private float maxBlindness, currentBlindness;
    private bool secondTimeRunning;

    void Start()
    {
        //converte pra uma variavel local, ja que a original � int
        maxBlindness = playerScript.maxBlindness;
    }
    void Update()
    {
        //converte pra uma variavel local, ja que a original � int
        currentBlindness = playerScript.currentBlindness;
        //primeiro descobre a porcentagem da vis�o atual em rela��o ao maximo
        currentSightPercent = (currentBlindness / maxBlindness);
        sight.pointLightOuterRadius = outerRadiusBase * currentSightPercent;
        //Debug.Log(currentSightPercent);
    }
}
