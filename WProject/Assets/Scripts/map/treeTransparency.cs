using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeTransparency : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("entro");
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.60f);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("saiu");
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
