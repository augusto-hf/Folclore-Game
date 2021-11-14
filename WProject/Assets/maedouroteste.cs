using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maedouroteste : MonoBehaviour
{
    public GameObject player, boitata, tro�o1, tro�o2, tro�o3;
    public bool telefone;
    
    void Update()
    {
        if (!telefone)
        {
            if (2.5f >= Vector2.Distance(player.transform.position, transform.position))
            {
                tro�o1.SetActive(true);
                tro�o2.SetActive(true);
                //tro�o3.SetActive(true);
                boitata.SetActive(false);
            }
        }
        else if (telefone)
        {
            if (1.5f >= Vector2.Distance(player.transform.position, transform.position))
            {
                boitata.SetActive(true);
            }
        }
    }
}
