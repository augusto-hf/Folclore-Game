using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    bool _PlayerHasEnter;
    [SerializeField]GameObject _IconShow;
    void Update()
    {
        if (Input.GetKeyDown("i") && _PlayerHasEnter == true)
        {
            Debug.Log("Enter");
            TriggerDialogue();
            _PlayerHasEnter = false;
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
            _PlayerHasEnter = true;
            
            _IconShow.SetActive(true);

        }
      
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Enter");
        if (other.tag == "Player")
        {
            _PlayerHasEnter = false;
            _IconShow.SetActive(false);

        }

    }

}