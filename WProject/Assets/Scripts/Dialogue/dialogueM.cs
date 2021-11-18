using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueM : MonoBehaviour
{

    public Text nameText;
    [SerializeField] Text dialogueText;
    [SerializeField] GameObject DialogBox;
    [SerializeField] AudioSource voiceLinesSource;

    public Animator animator;

    private Queue<string> sentences;
    private Queue<AudioClip> voiceLines;
    private bool haveAudio;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>();
        voiceLines = new Queue<AudioClip>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //FindObjectOfType<shooting>()._PlayerStardDialogue = true;
        //animator.SetBool("IsOpen", true);

        //JEITO SIMPLES DE SABER SE TEM AUDIO (If simplificado ao maximo)
        haveAudio = dialogue.voiceLines.Length == 0 ? false : true;

        DialogBox.SetActive(true);


        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        if (haveAudio)
        {
            foreach (AudioClip voiceLine in dialogue.voiceLines)
            {
                voiceLines.Enqueue(voiceLine);
            }
        }

        Debug.Log("Start Dialogue");
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }


        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        Debug.Log("Next Sentence");

        //Tocar o atual da fila Audio
        if (haveAudio)
        {
            voiceLinesSource.Stop();
            AudioClip voiceLine = voiceLines.Dequeue();
            voiceLinesSource.PlayOneShot(voiceLine);
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        //animator.SetBool("IsOpen", false);
        Debug.Log("Fechei");
        if (haveAudio)
        {
            voiceLinesSource.Stop();
        }
        DialogBox.SetActive(false);
        //FindObjectOfType<shooting>()._PlayerStardDialogue = false;
    }

}