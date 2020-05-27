using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUIController : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] protected GameObject ResilientAbilityUI;
    [SerializeField] protected GameObject UnlockingAbilityUI;
    [SerializeField] protected GameObject XraysAbilityUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AbilityPickedUp(AbilityTypes type)
    {
        switch (type)
        {
            case AbilityTypes.RESILIENT:
                ResilientAbilityUI.GetComponent<Animator>().SetBool("Ability", true);
                break;
            case AbilityTypes.UNLOCKING:
                UnlockingAbilityUI.GetComponent<Animator>().SetBool("Ability", true);
                break;
            case AbilityTypes.M_RAYS:
                XraysAbilityUI.GetComponent<Animator>().SetBool("Ability", true);
                break;
        }
    }
}
