using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshManager : MonoBehaviour
{
    [HideInInspector]
    public Transform followObjective;

    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void ActualizeObjectivePointNavMeshAgent(Vector3 ObjectivePoint)
    {
        navMeshAgent.destination = ObjectivePoint;
        navMeshAgent.isStopped = false;
    }

    public void ActualizeObjectivePointNavMeshAgent()
    {
        ActualizeObjectivePointNavMeshAgent(followObjective.position);
    }

    public void StopNavMeshAgent()
    {
        navMeshAgent.isStopped = true;
    }

    public bool hasArrived()
    {
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending;
    }
}
