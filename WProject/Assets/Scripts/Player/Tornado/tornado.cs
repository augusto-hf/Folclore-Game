using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tornado : MonoBehaviour
{
    private float transitionState;
    public Transform target;
    private float initialD;

    void Start()
    {
        initialD = Vector2.Distance(transform.position, target.position);
    }

    void Update()
    {
        transitionState += Time.deltaTime;
        if (transitionState > 1F)
        {
            //Being added to inventory code
            return;
        }
        float tdiff = initialD * transitionState;
        float ad = Vector2.Distance(transform.position, target.position);
        if (ad > tdiff)
        {
            Vector2 npos = Vector2.MoveTowards(transform.position, target.position, ad - tdiff);
            transform.position = npos;
        }

    }
}
