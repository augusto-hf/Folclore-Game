using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeHive : MonoBehaviour
{
    public GameObject bees;
    public Collider2D playerFinder;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bees.active = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        bees.active = false;
    }
}
