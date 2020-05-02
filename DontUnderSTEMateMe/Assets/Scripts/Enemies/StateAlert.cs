using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAlert : MonoBehaviour
{
    public float timeFinded = 5f;

    private StateMachine statesMachine;
    private NavMeshManager navMeshManager;
    private VisionManager visionManager;
    private float timeFinding;
    private Animator anim;

    private void Awake()
    {
        statesMachine = GetComponent<StateMachine>();
        navMeshManager = GetComponent<NavMeshManager>();
        visionManager = GetComponent<VisionManager>();
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        anim.SetBool("Walk Forward", true);
        navMeshManager.StopNavMeshAgent();
        timeFinding = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (visionManager.canSeeToThePlayer(out hit))
        {
            anim.SetBool("Walk Forward", false);
            navMeshManager.followObjective = hit.transform;
            statesMachine.ActivateState(statesMachine.StatePursuit);
            return;
        }

        transform.Rotate(0.0f, 50.0f * Time.deltaTime, 0.0f);
        timeFinding += Time.deltaTime;
        if(timeFinding >= timeFinded)
        {
            anim.SetBool("Walk Forward", false);
            statesMachine.ActivateState(statesMachine.StatePatrol);
            return;
        }
    }
}
