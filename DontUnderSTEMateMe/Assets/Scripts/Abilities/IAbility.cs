using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This interface defines the funtions that every ability
/// must implement
/// </summary>
public abstract class Ability : MonoBehaviour
{
    [HideInInspector]
    public AbilityTypes abilityType;

    /// <summary>
    /// This functions is called by the player to invoke
    /// the ability
    /// </summary>
    public abstract void Interact();
}


public enum AbilityTypes
{
    NONE,
    UNLOCKING,
    M_RAYS
}
