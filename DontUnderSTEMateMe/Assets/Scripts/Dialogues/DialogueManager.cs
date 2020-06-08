using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Invector.vCharacterController;


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
    protected Queue<string> sentences;

    [SerializeField]
    protected GameObject dialoguePanel;

    [SerializeField]
    protected Text displayText;

    protected string activeSentence;

    protected bool isInConversation = false;

    [SerializeField]
    protected float typingSpeed;

    AudioSource myAudio;
    [SerializeField]
    protected AudioClip speakSound;

   // private Image enterImage;

    protected vThirdPersonInput playerInput;

    void Start()
    {
        sentences = new Queue<string>();
        myAudio = GetComponent<AudioSource>();
        //enterImage = enterImage.transform.GetChild(1).GetComponent<Image>();
    }

    void StartDialogue()
    {
        sentences.Clear();

        foreach (string sentence in dialogue.getDialogues())
        {
            sentences.Enqueue(sentence);
        }

        //Aqui iria sonido
        if (myAudio)
        {
            myAudio.clip = speakSound;
            myAudio.Play();
        }

        DisplayNextSentence();
    }

    public  virtual void DisplayNextSentence()
    {
        

        if(sentences.Count <= 0)
        {
            playerInput.isInDialog = false;
            /** Was on exit **/
            isInConversation = false;
            StopAllCoroutines();
            /*****************/
            dialoguePanel.SetActive(false);
            Destroy(this.gameObject);
            displayText.text = activeSentence;
            return;
        }

        dialoguePanel.transform.GetChild(1).GetComponent<Image>().enabled = false;
        dialoguePanel.transform.GetChild(1).GetComponentInChildren<Text>().enabled = false;

        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;

        StopAllCoroutines();
        StartCoroutine(TypetheSentence(activeSentence));
    }

    protected IEnumerator TypetheSentence(string sentence)
    {
        displayText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
            
            yield return new WaitForSeconds(typingSpeed);
        }
        // TODO: Mostrar enter
        dialoguePanel.transform.GetChild(1).GetComponent<Image>().enabled = true;
        dialoguePanel.transform.GetChild(1).GetComponentInChildren<Text>().enabled = true;
    }
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInput = other.GetComponent<vThirdPersonInput>();
            playerInput.isInDialog = true;
            isInConversation = true;
            dialoguePanel.SetActive(true);
            SetDialogColor();
            StartDialogue();
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInConversation = false;
            dialoguePanel.SetActive(false);
            StopAllCoroutines();
        }
    }

    protected void Update()
    {
        if (isInConversation)
        {
            if (Input.GetKeyDown(KeyCode.Return) && displayText.text == activeSentence)
            {
                DisplayNextSentence();
            }
        }
    }

    protected void SetDialogColor()
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
