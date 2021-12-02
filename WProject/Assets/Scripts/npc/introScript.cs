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

    
    void Start()
    {
        zeIntro.TriggerDialogue();
        blackScreen.SetActive(true);
        F.SetActive(true);
        followScript = ze.GetComponent<followPathWithPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (followScript == null)
        {
            followScript = ze.GetComponent<followPathWithPlayer>();
        }
        if (dialogueManager.dialogueHasEnded == true && zeIntro.enabled == true)
        {
            blackScreen.SetActive(false);
            followScript.enabled = true;
            zeIntro.enabled = false;
        }
        if (followScript.pathEnded)
        {
            blackScreen.SetActive(true);
            zeForest.enabled = true;
            if (Input.GetButtonDown("Interact"))
            {
                blackScreen.SetActive(false);
            }
        }
    }
}
