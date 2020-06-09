using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Invector.vCharacterController;

public class ExtendedDialogueManager : DialogueManager
{
    [Header("End callback")]
    [SerializeField] public UnityEvent endCallback;

    [SerializeField] protected float DestroyDelayAfterCallback = 1.0f;


     public override void DisplayNextSentence()
    {


        if (sentences.Count <= 0)
        {
            playerInput.isInDialog = false;
            /** Was on exit **/
            isInConversation = false;
            StopAllCoroutines();
            /*****************/
            StartCoroutine(EndDialog());
            return;
        }

        dialoguePanel.transform.GetChild(1).GetComponent<Image>().enabled = false;
        dialoguePanel.transform.GetChild(1).GetComponentInChildren<Text>().enabled = false;

        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;

        StopAllCoroutines();
        StartCoroutine(TypetheSentence(activeSentence));
    }

    private IEnumerator EndDialog()
    {

        if (endCallback != null)
            endCallback.Invoke();
        else
            Debug.LogError("No callback defined...");

        yield return new WaitForSeconds(DestroyDelayAfterCallback);

        dialoguePanel.SetActive(false);
        Destroy(this.gameObject);
        displayText.text = activeSentence;
    }

}
