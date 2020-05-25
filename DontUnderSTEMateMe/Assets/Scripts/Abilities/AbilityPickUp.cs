using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickUp : MonoBehaviour
{
    [SerializeField]
    protected ParticleSystem[] particleSystems;

    [Header("Climax properties")]
    [SerializeField] protected ParticleSystem climaxParticles;
    [SerializeField] protected AudioSource climaxAudio;
    [SerializeField] protected float ClimaxSoundDelay = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

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


    }
}
