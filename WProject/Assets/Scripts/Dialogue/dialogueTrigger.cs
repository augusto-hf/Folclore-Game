using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
    [SerializeField] dialogueM dialogM_script;
    public Dialogue dialogue;
    bool playerHasEnter, dialogHasStarted;
    [SerializeField]GameObject _IconShow;

    

    private void Start()
    {
    }
    void Update()
    {
        if (Input.GetButtonDown("Interact") && playerHasEnter == true)
        {
            //Debug.Log("Enter");
            TriggerDialogue();
        }
        else if (Input.GetButtonDown("Interact") && dialogHasStarted == true)
        {
            dialogM_script.DisplayNextSentence();
        }
    }

    public void TriggerDialogue()
    {
        dialogM_script.StartDialogue(dialogue);
        playerHasEnter = false;
        dialogHasStarted = true;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Enter");
        if (other.tag == "Player")
        {
            playerHasEnter = true;
            
            _IconShow.SetActive(true);

        }
      
    }
    void OnTriggerExit2D(Collider2D other)
    {
       //Debug.Log("Exit");
        if (other.tag == "Player")
        {
            playerHasEnter = false;
            dialogHasStarted = false;
            _IconShow.SetActive(false);

            dialogM_script.EndDialogue();
        }

    }

}