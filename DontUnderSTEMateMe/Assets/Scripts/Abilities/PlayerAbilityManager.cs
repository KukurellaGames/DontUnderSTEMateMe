using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour
{
    private AbilityTypes activeAbility;

    // Ability
    private bool canUseAbility = false;
    private GameObject abilityGameObject;

    private void Start()
    {
        activeAbility = AbilityTypes.RESILIENT;
        //activeAbility = AbilityTypes.M_RAYS;
        //activeAbility = AbilityTypes.UNLOCKING;
    }

    private void Update()
    {
        if(Input.GetKey("e"))
        {
            Interact();
        }

    }

    /// <summary>
    /// Checks when the player is able to use an ability
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ability")
        {
            canUseAbility = true;
            abilityGameObject = other.gameObject;
            Debug.Log("Entro");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ability")
        {
            canUseAbility = false;
            abilityGameObject = null;
            Debug.Log("Salgo");
        }
    }

    /// <summary>
    /// Function called by the user to use an ability
    /// The ability that is used is the one in activeAbility
    /// </summary>
    public void Interact()
    {
        if (canUseAbility && checkAbilityType())
        {
            Ability ability = abilityGameObject.gameObject.GetComponent<Ability>();
            ability.Interact();
        }
    }

    private bool checkAbilityType()
    {
        Ability ability = abilityGameObject.GetComponent<Ability>();
        if (ability == null)
        {
            Debug.Log("NULO");
            return false;
        }

        if (ability.abilityType == activeAbility)
            return true;
        else
            return false;
    }
}
