using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class pulseLightFx : MonoBehaviour
{
    [SerializeField] float pulseSpeed, max = 1, min = 0.1f;
    private Light2D logoLight2D;
    void Start()
    {
        logoLight2D = GetComponent<Light2D>();
    }
    void Update()
    {
        logoLight2D.intensity = (Mathf.PingPong(Time.time * pulseSpeed, max))+ min;
    }
}
