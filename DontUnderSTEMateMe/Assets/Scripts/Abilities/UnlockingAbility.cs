using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingAbility : Ability
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.LogError("[Unlocking Ability] Error getting animator reference");
    }

    #region IAbility
    /// <summary>
    /// This functions is called by the player when
    /// interacts with the ability
    /// </summary>
    public override void Interact() 
    {
        animator.SetTrigger("Open");
    }
    #endregion
}
