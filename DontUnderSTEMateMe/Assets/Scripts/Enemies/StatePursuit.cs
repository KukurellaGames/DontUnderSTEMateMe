using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePursuit : MonoBehaviour
{
    private StateMachine statesMachine;
    private NavMeshManager navMeshManager;
    private VisionManager visionManager;
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        statesMachine = GetComponent<StateMachine>();
        navMeshManager = GetComponent<NavMeshManager>();
        visionManager = GetComponent<VisionManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        try
        {
            if (!visionManager.canSeeToThePlayer(out hit, true))
            {
                anim.SetBool("Run Forward", false);
                statesMachine.ActivateState(statesMachine.StateAlert);
                return;
            }
        }
        catch(Exception e)
        {
            statesMachine.ActivateState(statesMachine.StatePatrol);
        }

        navMeshManager.ActualizeObjectivePointNavMeshAgent();
    }

    void OnEnable()
    {
        anim.SetBool("Run Forward", true);
    }
}
