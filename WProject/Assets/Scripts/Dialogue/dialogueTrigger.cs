﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
    public dialogueM dialogM_script;
    public Dialogue dialogue;
    bool playerHasEnter, dialogHasStarted;
    [SerializeField]GameObject _IconShow;

    private void Start()
    {
        dialogM_script = GameObject.FindGameObjectWithTag("scriptObject").GetComponent<dialogueM>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Interact") && playerHasEnter == true)
        {
            //Debug.Log("Enter");
            TriggerDialogue();
            playerHasEnter = false;
            dialogHasStarted = true;
        }
        else if (Input.GetButtonDown("Interact") && dialogHasStarted == true)
        {
            dialogM_script.DisplayNextSentence();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<dialogueM>().StartDialogue(dialogue);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
        if (other.tag == "Player")
        {
            playerHasEnter = true;
            
            _IconShow.SetActive(true);

        }
      
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit");
        if (other.tag == "Player")
        {
            playerHasEnter = false;
            _IconShow.SetActive(false);

            FindObjectOfType<dialogueM>().EndDialogue();
        }

    }

}