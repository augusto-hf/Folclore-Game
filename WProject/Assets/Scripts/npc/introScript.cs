using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introScript : MonoBehaviour
{
    public GameObject blackScreen, ze;
    public dialogueTrigger zeIntro, zeForest;
    public dialogueM dialogueManager;
    public followPathWithPlayer followScript;

    // Start is called before the first frame update
    void Start()
    {
        zeIntro.TriggerDialogue();
        blackScreen.active = true;
        followScript = ze.GetComponent<followPathWithPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (followScript == null)
        {
            followScript = ze.GetComponent<followPathWithPlayer>();
        }
        if (dialogueManager.dialogueHasEnded == true)
        {
            blackScreen.active = false;
            followScript.enabled = true;
        }
        else if (blackScreen.active == false)
        {

        }
    }
}
