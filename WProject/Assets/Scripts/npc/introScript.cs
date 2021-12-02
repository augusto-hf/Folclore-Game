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
        if (followScript.pathEnded && hasTeleported == false)
        {
            hasTeleported = true;
            blackScreen.SetActive(true);
            player.transform.position = teleportPoint.transform.position + new Vector3(2,0,0);
            ze.transform.position = teleportPoint.transform.position + new Vector3(-2, 0, 0);
            F.SetActive(true);
            zeForest.enabled = true;
        }
        if (Input.GetButtonDown("Interact") && hasTeleported == true)
        {
            blackScreen.SetActive(false);
        }
        if (Input.GetButtonDown("Interact"))
        {
            F.SetActive(false);
        }
    }
}
