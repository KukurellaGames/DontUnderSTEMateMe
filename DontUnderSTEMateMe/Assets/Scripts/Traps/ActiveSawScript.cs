using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSawScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private AudioSource _clip;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Active");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _clip.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _clip.Stop();
        }
    }
}
