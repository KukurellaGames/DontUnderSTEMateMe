using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingAbility : Ability
{
    [SerializeField] private ParticleSystem IdleParticles;
    [SerializeField] private ParticleSystem ClimaxParticles;

    private Animator animator;

    private bool IsLocked;

    private void Start()
    {
        abilityType = AbilityTypes.UNLOCKING;
        // Get animator reference
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.LogError("[Unlocking Ability] Error getting animator reference");

        // Set idle particles to its initial state
        try
        {
            IdleParticles.time = 5.0f;
            for (int i = 0; i < IdleParticles.transform.childCount; i++)
            {
                ParticleSystem idleKeys = IdleParticles.transform.GetChild(i).GetComponent<ParticleSystem>();
                if (idleKeys != null)
                {
                    idleKeys.time = 5.0f;
                }

            }
            IdleParticles.Play();
        }catch(Exception e)
        {
            Debug.Log("Idle particles not found");
        }
        // Set door locked
        IsLocked = false;
    }

    #region IAbility
    /// <summary>
    /// This functions is called by the player when
    /// interacts with the ability
    /// </summary>
    public override void Interact() 
    {
        StartCoroutine(InteractionRoutine());
    }
    #endregion

    private IEnumerator InteractionRoutine()
    {
        if (!IsLocked)
        {
            IsLocked = true;
            // Stop loop in idle particles - this will fade particles
            var idleMain = IdleParticles.main;
            idleMain.loop = false;
            for (int i = 0; i < IdleParticles.transform.childCount; i++)
            {
                ParticleSystem idleKeys = IdleParticles.transform.GetChild(i).GetComponent<ParticleSystem>();
                if (idleKeys != null)
                {
                    var idleKeysMain = idleKeys.main;
                    idleKeysMain.loop = false;
                }

            }
            yield return new WaitForSeconds(0.5f);

            // Start climax particles
            ClimaxParticles.Play();
            yield return new WaitForSeconds(1.5f);

            // Open door
            animator.SetTrigger("Open");
        }
        
    }
}
