using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introScript : MonoBehaviour
{
    public GameObject blackScreen, ze;
    public dialogueM dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        ze.GetComponent<dialogueTrigger>().TriggerDialogue();
        blackScreen.active = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueManager.dialogueHasEnded == true)
        {
            blackScreen.active = false;
            ze.GetComponent<followPathWithPlayer>().enabled = true;
        }
        else if (blackScreen.active == false)
        {

        }
    }
}
