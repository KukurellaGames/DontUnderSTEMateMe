using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public enum DialogueType
{
    Friendly,
    UnFriendly,
    OwnThinking
}

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    protected DialogueType type;

    [SerializeField]
    protected Dialogue dialogue;

    //Manejar las oraciones
    Queue<string> sentences;

    [SerializeField]
    protected GameObject dialoguePanel;

    [SerializeField]
    protected TextMeshProUGUI displayText;

    private string activeSentence;

    private bool isInConversation = false;

    [SerializeField]
    protected float typingSpeed;

    AudioSource myAudio;
    [SerializeField]
    protected AudioClip speakSound;

    void Start()
    {
        sentences = new Queue<string>();
        myAudio = GetComponent<AudioSource>();
    }

    void StartDialogue()
    {
        sentences.Clear();

        foreach (string sentence in dialogue.getDialogues())
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {
        if(sentences.Count <= 0)
        {
            dialoguePanel.SetActive(false);
            Destroy(this.gameObject);
            displayText.text = activeSentence;
            return;
        }

        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;

        StopAllCoroutines();
        StartCoroutine(TypetheSentence(activeSentence));
    }

    IEnumerator TypetheSentence(string sentence)
    {
        displayText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
            //Aqui iria sonido
            //myAudio.PlayOneShot(speakSound);
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInConversation = true;
            dialoguePanel.SetActive(true);
            SetDialogColor();
            StartDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInConversation = false;
            dialoguePanel.SetActive(false);
            StopAllCoroutines();
        }
    }

    private void Update()
    {
        if (isInConversation)
        {
            if (Input.GetKeyDown(KeyCode.Return) && displayText.text == activeSentence)
            {
                DisplayNextSentence();
            }
        }
    }

    private void SetDialogColor()
    {
        Color color = new Color(0,0,0,160.0f/255.0f); // Default color

        switch (type)
        {
            case DialogueType.Friendly:
                color = new Color(0.0f, 60.0f / 255.0f, 0, 160.0f / 255.0f); // Greenish
                break;
            case DialogueType.UnFriendly:
                color = new Color(60.0f/255.0f, 0, 0, 160.0f/255.0f); // Redish
                break;
            case DialogueType.OwnThinking:
                color = new Color(60.0f / 255.0f, 60.0f / 255.0f, 0, 160.0f / 255.0f); // Yellowish
                break;
        }

        dialoguePanel.GetComponent<Image>().color = color;
        
    }
}
