using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementNavMesh : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;
    Vector3 movement = Vector3.zero;

    private void Update()
    {
        movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement += transform.forward * -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement += transform.right * -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right;
        }

        movement += transform.position + movement;
        movement.y = transform.position.y;
        agent.destination = movement;
        Debug.Log($"AGENT :: {agent.destination}");
        Debug.Log($"MOVEMENT :: {movement}");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, movement);
    }
}
