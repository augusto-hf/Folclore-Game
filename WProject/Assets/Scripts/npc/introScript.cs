using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introScript : MonoBehaviour
{
    public GameObject blackScreen, F, ze, player, teleportPoint;
    public dialogueTrigger zeIntro, zeForest;
    public dialogueM dialogueManager;
    public followPathWithPlayer followScript;

    public int enemyCount;
    public bool hasTeleported = false;
    
    void Start()
    {
        zeIntro.TriggerDialogue();
        blackScreen.SetActive(true);
        F.SetActive(true);
        followScript = ze.GetComponent<followPathWithPlayer>();
    }

    void Update()
    {
        if (followScript == null)
        {
            followScript = ze.GetComponent<followPathWithPlayer>();
        }
        if (dialogueManager.dialogueHasEnded == true)
        {
            if (zeIntro.enabled == true)
            {
                blackScreen.SetActive(false);
                followScript.enabled = true;
                dialogueManager.dialogueHasEnded = false;
                zeIntro.enabled = false;
            }
            if (zeForest.enabled == true)
            {
                blackScreen.SetActive(false);
            }
        }
        if (followScript.pathEnded)
        {
            zeForest.enabled = true;
            followScript.enabled = false;
        }
        if (Input.GetButtonDown("Interact") && dialogueManager.dialogueHasStarted == true && zeForest.enabled == true)
        {
            blackScreen.SetActive(true);
            player.transform.position = teleportPoint.transform.position;
        }
    }
}
