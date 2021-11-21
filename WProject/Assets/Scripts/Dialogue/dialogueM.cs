using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueM : MonoBehaviour
{

    public Text nameText;
    [SerializeField] Text dialogueText;
    [SerializeField] GameObject DialogBox, playerImage, NpcImage, playerImageBack, NpcImageBack;
    [SerializeField] AudioSource voiceLinesSource;
    [SerializeField] Animator NpcImageAnimator, NpcImageBackAnimator;


    public Animator animator;

    private Queue<string> sentences;
    private Queue<AudioClip> voiceLines;
    private Queue<bool> isNpcLines;
    private string npcName;
    private bool haveAudio;

    //Tentando Fazer o CD do dialogo
    public float dialogueSpeed = 10f;
    public float nextDialogue = 0f;

    void Start()
    {
        sentences = new Queue<string>();
        voiceLines = new Queue<AudioClip>();
        isNpcLines = new Queue<bool>();
        NpcImageAnimator = NpcImage.GetComponent<Animator>();
        NpcImageBackAnimator = NpcImageBack.GetComponent<Animator>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //FindObjectOfType<shooting>()._PlayerStardDialogue = true;
        //animator.SetBool("IsOpen", true);


        //JEITO SIMPLES DE SABER SE TEM AUDIO (If simplificado ao maximo)
        haveAudio = dialogue.voiceLines.Length == 0 ? false : true;

        DialogBox.SetActive(true);

        //defini nome do npc
        npcName = dialogue.name;

        //define imagem e animaçao do npc
        NpcImage.GetComponent<Image>().sprite = dialogue.NpcImage;
        NpcImageAnimator.SetBool("hasEnter", true);
        
        NpcImageBack.GetComponent<Image>().sprite = dialogue.NpcImage;
        NpcImageBackAnimator.SetBool("hasEnter", true);

        //limpa as queue antigas pra evitar bugs
        sentences.Clear();
        isNpcLines.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (bool isNpcLine in dialogue.isNpcLines)
        {
            isNpcLines.Enqueue(isNpcLine);
        }

        if (haveAudio)
        {
            voiceLines.Clear();
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

        //verificar se é npc ou jogador falando
        bool isNpcLine = isNpcLines.Dequeue();
        if (isNpcLine)
        {
            nameText.text = npcName;
            NpcImage.SetActive(true);
            playerImage.SetActive(false);
        }
        else
        {
            nameText.text = "Aiyra";
            NpcImage.SetActive(false);
            playerImage.SetActive(true);
        }


        //escrever a mensagem
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
        NpcImage.SetActive(true);
        NpcImageAnimator.SetBool("hasEnter", false);
        NpcImageBackAnimator.SetBool("hasEnter", false);

        DialogBox.SetActive(false);
        //FindObjectOfType<shooting>()._PlayerStardDialogue = false;
    }
}