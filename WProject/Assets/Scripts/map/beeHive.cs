using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeHive : MonoBehaviour
{
    public GameObject bees;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("entro");
        bees.active = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        bees.active = false;
    }
}
