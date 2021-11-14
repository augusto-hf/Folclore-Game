using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maedouroteste : MonoBehaviour
{
    public GameObject player, boitata, troço1, troço2, troço3;
    public bool telefone;
    
    void Update()
    {
        if (!telefone)
        {
            if (2.5f >= Vector2.Distance(player.transform.position, transform.position))
            {
                troço1.SetActive(true);
                troço2.SetActive(true);
                //troço3.SetActive(true);
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
