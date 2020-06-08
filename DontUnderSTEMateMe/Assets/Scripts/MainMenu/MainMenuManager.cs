using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Animator[] animators;

    

    public void OnPlayPressed()
    {
        CheckDontDestroyAnimator();
        foreach (Animator animator in animators)
        {
            animator.SetTrigger("PlayPressed");
        }
    }

    public void OnMainMenu()
    {
        CheckDontDestroyAnimator();
        foreach (Animator animator in animators)
        {
            animator.SetTrigger("MainMenu");
        }
    }

    public void OnCollectableShow()
    {
        CheckDontDestroyAnimator();
        foreach (Animator animator in animators)
        {
            animator.SetTrigger("ShowCollectableList");
        }
    }


    private void CheckDontDestroyAnimator()
    {
        // Sory :'(
        if (animators[3] == null)
            animators[3] = GameObject.FindGameObjectWithTag("CollectableList").GetComponent<Animator>();
    }
}
