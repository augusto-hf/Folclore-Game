using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maedouroteste : MonoBehaviour
{
    public GameObject player, troço1, troço2, troço4;
    public dialogueM dialogManager;
    public bool playerNear= false;

    void Update()
    {
            if (playerNear && dialogManager.sentences.Count == 0)
            {
                troço1.SetActive(true);
                troço2.SetActive(true);
                troço4.SetActive(false);
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
