using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour
{
    //private Dictionary<AbilityTypes, bool> ActiveAbility;
    private AbilityContainer _containerAbility;
    // Ability
    private bool canUseAbility = false;
    private GameObject abilityGameObject;

    private void Start()
    {
        //initDictionary();
        _containerAbility = GameObject.FindGameObjectWithTag("GameController").GetComponent<AbilityContainer>(); 
    }

    private void Update()
    {
        if(Input.GetKey("e"))
        {
            Interact();        }
    }
    /*
    private void initDictionary()
    {
        ActiveAbility = new Dictionary<AbilityTypes, bool>();

        var values = AbilityTypes.GetValues(typeof(AbilityTypes));
        foreach(AbilityTypes value in values)
        {
            ActiveAbility[value] = false;
        }
    }*/

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

        // Check value in dictionary
        return _containerAbility.ActiveAbility[ability.abilityType];
        //return ActiveAbility[ability.abilityType];

    }

    public void AbilityPickedUp(AbilityTypes type)
    {
        if(type == AbilityTypes.NONE)
        {
            Debug.LogError("[PlayerAbilityManager] This ability is set to NONE");
            return;
        }
        //ActiveAbility[type] = true;
        _containerAbility.ActiveAbility[type] = true;
    }
}
