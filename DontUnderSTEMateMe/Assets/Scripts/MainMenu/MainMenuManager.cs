using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Animator[] animators;

    public void OnPlayPressed()
    {
        foreach(Animator animator in animators)
        {
            animator.SetTrigger("PlayPressed");
        }
    }

    public void OnMainMenu()
    {
        foreach (Animator animator in animators)
        {
            animator.SetTrigger("MainMenu");
        }
    }

}
