using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class logoLightFx : MonoBehaviour
{
    [SerializeField] float pulseSpeed;
    private Light2D logoLight2D;
    void Start()
    {
        logoLight2D = GetComponent<Light2D>();
    }
    void Update()
    {
        logoLight2D.intensity = Mathf.PingPong(Time.time * pulseSpeed, 1);
    }
}
