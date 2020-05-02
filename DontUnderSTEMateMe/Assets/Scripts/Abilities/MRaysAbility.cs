using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRaysAbility : Ability
{
    [SerializeField] protected GameObject ResultMesh;

    [SerializeField] private ParticleSystem IdleParticles;
    [SerializeField] private ParticleSystem ClimaxParticles;

    [Tooltip("This is the max alpha that the shader will show")]
    [SerializeField] private float MaxAlpha;
    [SerializeField] private float eachStepIncrement;


    private bool IsActivated;

    // Start is called before the first frame update
    void Start()
    {
        abilityType = AbilityTypes.M_RAYS;

        ResultMesh.GetComponent<MeshRenderer>().material.SetFloat("_Alpha", 0.0f);
        ResultMesh.GetComponent<MeshRenderer>().enabled = false;
        ResultMesh.GetComponent<Collider>().enabled = false;

        /******* Particles ********/
        // Set idle particles to its initial state
        IdleParticles.time = 5.0f;
        for (int i = 0; i < IdleParticles.transform.childCount; i++)
        {
            ParticleSystem idleAtoms = IdleParticles.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (idleAtoms != null)
            {
                idleAtoms.time = 5.0f;
            }

        }
        IdleParticles.Play();

        IsActivated = false;
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
        if (!IsActivated)
        {
            IsActivated = true;

            // Stop loop in idle particles - this will fade particles
            var idleMain = IdleParticles.main;
            idleMain.loop = false;
            for (int i = 0; i < IdleParticles.transform.childCount; i++)
            {
                ParticleSystem idleAtoms = IdleParticles.transform.GetChild(i).GetComponent<ParticleSystem>();
                if (idleAtoms != null)
                {
                    var idleKeysMain = idleAtoms.main;
                    idleKeysMain.loop = false;
                }

            }
            yield return new WaitForSeconds(0.5f);

            // Start climax particles
            ClimaxParticles.Play();
            yield return new WaitForSeconds(1.5f);

            /* Show result mesh */
            ResultMesh.GetComponent<MeshRenderer>().enabled = true;
            StartCoroutine(ResultMeshOpacityRoutine());
            yield return new WaitForSeconds(0.0f);
            ResultMesh.GetComponent<Collider>().enabled = true;
            GetComponent<BoxCollider>().enabled = false;
            /**/
        }

    }

    private IEnumerator ResultMeshOpacityRoutine()
    {
        Material mat = ResultMesh.GetComponent<MeshRenderer>().material;
        while (mat.GetFloat("_Alpha") < MaxAlpha)
        {
            float thisAlpha = mat.GetFloat("_Alpha");
            mat.SetFloat("_Alpha", thisAlpha + eachStepIncrement);
            yield return new WaitForSeconds(eachStepIncrement);
        }
        
    }
}
