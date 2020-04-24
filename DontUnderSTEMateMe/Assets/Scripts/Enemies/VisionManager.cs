using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionManager : MonoBehaviour
{
    public Transform Eyes;
    public float rangeVision;

    // Para que no mire a los pies del jugador
    public Vector3 offset = new Vector3(0f, 0.5f, 0f);

    private NavMeshManager navMeshManager;

    private void Awake()
    {
        navMeshManager = GetComponent<NavMeshManager>();
    }

    public bool canSeeToThePlayer(out RaycastHit hit, bool lookToThePlayer = false)
    {
        Vector3 vectorDirection;
        if (lookToThePlayer)
        {
            vectorDirection = (navMeshManager.followObjective.position + offset) - Eyes.position;
        }
        else
        {
            vectorDirection = Eyes.forward;
        }
        return Physics.Raycast(Eyes.position, vectorDirection, out hit, rangeVision) && hit.collider.CompareTag("Player");
    }
}
