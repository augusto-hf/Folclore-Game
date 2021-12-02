using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maedouroteste : MonoBehaviour
{
    public GameObject player, tro�o1, tro�o2, tro�o4;
    public dialogueM dialogManager;
    public bool playerNear= false;

    void Update()
    {
            if (playerNear && dialogManager.sentences.Count == 0)
            {
                tro�o1.SetActive(true);
                tro�o2.SetActive(true);
                tro�o4.SetActive(false);
            }
    }
    private void OnTriggerEnter(Collider other)
    {
        playerNear = true;
    }
    private void OnTriggerExit(Collider other)
    {
        playerNear = false;
    }

}
