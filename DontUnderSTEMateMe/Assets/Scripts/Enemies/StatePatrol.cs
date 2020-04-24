using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrol : MonoBehaviour
{
    public Transform[] Waypoint;

    private StateMachine statesMachine;
    private NavMeshManager navMeshManager;
    private VisionManager visionManager;
    private int nextWayPoint;

    // Start is called before the first frame update
    void Awake()
    {
        statesMachine = GetComponent<StateMachine>();
        navMeshManager = GetComponent<NavMeshManager>();
        visionManager = GetComponent<VisionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // See the player
        RaycastHit hit;
        if(visionManager.canSeeToThePlayer(out hit))
        {
            navMeshManager.followObjective = hit.transform;
            statesMachine.ActivateState(statesMachine.StatePursuit);
            return;
        }

        if (navMeshManager.hasArrived())
        {
            nextWayPoint = (nextWayPoint + 1) % Waypoint.Length;
            ActualizeWayPoint();
        }
    }

    void OnEnable()
    {
        ActualizeWayPoint();
    }

    void ActualizeWayPoint()
    {
        navMeshManager.ActualizeObjectivePointNavMeshAgent(Waypoint[nextWayPoint].position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && enabled)
        {
            Debug.Log("Ha entrado");
            statesMachine.ActivateState(statesMachine.StateAlert);
        }
    }
}
