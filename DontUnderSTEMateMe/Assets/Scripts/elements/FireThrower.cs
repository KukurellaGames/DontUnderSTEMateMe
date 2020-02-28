using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireThrower : MonoBehaviour
{
    [Header("Delay Parameters")]
    [Tooltip("Time legth that the fire is visible")]
    [SerializeField] protected float FireDuration = 3.0f;

    [Tooltip("Time tha the fire remains stopped")]
    [SerializeField] protected float IdleTime = 6.0f;

    [Tooltip("This is the time delayed until the fire starts, Used to configure the different between different flames.")]
    [SerializeField] protected float StartDelay = 0.0f;

    private ParticleSystem particles;
    private BoxCollider fireCollider;
    private bool isActive = true;


    // Start is called before the first frame update
    void Start()
    {
        // Particles
        particles = GetComponentInChildren<ParticleSystem>();
        var main = particles.main;
        main.duration = FireDuration;

        // Collider
        fireCollider = GetComponentInChildren<BoxCollider>();
        fireCollider.enabled = false;

        StartCoroutine(FireThrowerRoutine());
    }

    private IEnumerator FireThrowerRoutine()
    {
        yield return new WaitForSeconds(StartDelay);
        
        while (isActive)
        {
            particles.Play();
            // Spawn collider
            fireCollider.enabled = true;
            yield return new WaitForSeconds(FireDuration);
            // Hide collider
            fireCollider.enabled = false;
            yield return new WaitForSeconds(IdleTime);
        }
        

    }
}
