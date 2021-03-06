﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    protected Dialogue dialogue;

    //Manejar las oraciones
    Queue<string> sentences;

    [SerializeField]
    protected GameObject dialoguePanel;

    [SerializeField]
    protected TextMeshProUGUI displayText;

    string activeSentence;

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
            dialoguePanel.SetActive(true);
            StartDialogue();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Return) && displayText.text == activeSentence)
            {
                DisplayNextSentence();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialoguePanel.SetActive(false);
            StopAllCoroutines();
        }
    }
}
