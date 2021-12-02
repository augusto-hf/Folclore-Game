using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maedouroteste : MonoBehaviour
{
    public GameObject player, troço1, troço2, troço3;
    public dialogueM dialogManager;
    public bool playerNear= false;

    void Update()
    {
            if (playerNear && dialogManager.sentences.Count)
            {
                troço1.SetActive(true);
                troço2.SetActive(true);
                troço3.SetActive(true);
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
