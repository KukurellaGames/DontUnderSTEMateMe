using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickUp : MonoBehaviour
{
    [Header("Ability Type")]
    [SerializeField] protected AbilityTypes abilityType;

    [Header("Particles")]
    [SerializeField] protected ParticleSystem[] particleSystems;

    [Header("Climax properties")]
    [SerializeField] protected ParticleSystem climaxParticles;
    [SerializeField] protected AudioSource climaxAudio;
    [SerializeField] protected float ClimaxSoundDelay = 1.5f;

    //Ability manager reference
    [Header("Ability Manager")]
    [Tooltip("This is the name of the game object that is containing ")]
    [SerializeField] private string AbilityManagerName;

    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine(AbilityPickedUp());
    }


    private IEnumerator AbilityPickedUp()
    {
        // Stop particles
        for (int i = 0; i < particleSystems.Length; i++)
        {
            ParticleSystem particleSystem = particleSystems[i];
            var particle = particleSystem.main;
            particle.loop = false;
        }
        Destroy(GetComponent<Collider>());

        climaxParticles.Play();

        yield return new WaitForSeconds(ClimaxSoundDelay);
        climaxAudio.Play();

        NotifyAbilityPicked();
    }

    private void NotifyAbilityPicked()
    {
        GameObject.Find(AbilityManagerName).SendMessage("AbilityPickedUp", abilityType);
    }
}
