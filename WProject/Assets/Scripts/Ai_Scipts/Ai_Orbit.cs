using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Orbit : MonoBehaviour
{
    [SerializeField] float OrbitX;
    [SerializeField] float OrbitY;
    [SerializeField] float OrbitZ;
    [SerializeField] Transform center;

    [SerializeField] float rotSpeed;
    [SerializeField] bool cloacise;

    [SerializeField] float timer = 0;



    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        orbit();
        transform.LookAt(center);
    }

    void orbit()
    {
        if (cloacise)
        {
            float x = -Mathf.Cos(timer) * OrbitX;
            float z = Mathf.Sin(timer) * OrbitZ;

            Vector3 pos = new Vector3(x, OrbitY, z);
            transform.position = pos + center.position;
        }

        else
        {
            float x = Mathf.Cos(timer) * OrbitX;
            float z = Mathf.Sin(timer) * OrbitZ;

            Vector3 pos = new Vector3(x, OrbitY, z);
            transform.position = pos + center.position;
        }
    }
}
