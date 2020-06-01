using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSawScript : MonoBehaviour
{
    private Animator animator;

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
}
