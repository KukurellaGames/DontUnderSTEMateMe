using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    public MonoBehaviour StatePatrol;
    public MonoBehaviour StateAlert;
    public MonoBehaviour StatePursuit;

    public MonoBehaviour StateInitial;
    private MonoBehaviour StateActual;

    // Start is called before the first frame update
    void Start()
    {
        ActivateState(StateInitial);
    }

    public void ActivateState(MonoBehaviour newState)
    {
        if(StateActual != null) StateActual.enabled = false;
        StateActual = newState;
        StateActual.enabled = true;

    }
}
