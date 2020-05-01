using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRaysAbility : Ability
{
    [SerializeField] protected GameObject ResultMesh;


    private bool IsActivated;

    // Start is called before the first frame update
    void Start()
    {
        abilityType = AbilityTypes.M_RAYS;

        ResultMesh.GetComponent<MeshRenderer>().enabled = false;

        IsActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        /* Show result mesh */
        ResultMesh.GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.0f);

        /**/
    }
}
