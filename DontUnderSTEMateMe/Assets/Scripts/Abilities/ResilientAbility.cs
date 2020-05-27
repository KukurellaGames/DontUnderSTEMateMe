using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResilientAbility : Ability
{
    [Tooltip("This is the mesh that will be removed when ability is activated.")]
    [SerializeField] protected GameObject MovableMesh;

    [SerializeField] private ParticleSystem IdleParticles;
    [SerializeField] private ParticleSystem ClimaxParticles;

    // Start is called before the first frame update
    void Start()
    {
        abilityType = AbilityTypes.RESILIENT;

        // Show mesh at begining
        MovableMesh.GetComponent<MeshRenderer>().enabled = true;
        MovableMesh.GetComponent<Collider>().enabled = true;

        /******* Particles ********/
        // Set idle particles to its initial state
        IdleParticles.time = 5.0f;
        for (int i = 0; i < IdleParticles.transform.childCount; i++)
        {
            ParticleSystem idleDust = IdleParticles.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (idleDust != null)
            {
                idleDust.time = 5.0f;
            }

        }
        IdleParticles.Play();

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
        // Stop loop in idle particles - this will fade particles
        var idleMain = IdleParticles.main;
        idleMain.loop = false;
        for (int i = 0; i < IdleParticles.transform.childCount; i++)
        {
            ParticleSystem idleDust = IdleParticles.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (idleDust != null)
            {
                var idleKeysMain = idleDust.main;
                idleKeysMain.loop = false;
            }

        }
        yield return new WaitForSeconds(1.0f);

        // Start climax particles
        ClimaxParticles.Play();
        yield return new WaitForSeconds(2.5f);

        // Remove mesh and collider
        MovableMesh.GetComponent<MeshRenderer>().enabled = false;
        MovableMesh.GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(0.0f);
    }
}
