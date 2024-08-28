using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementNavMesh : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    Vector3 movement = Vector3.zero;

    private void Update()
    {
        movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.forward * -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
        }

        movement = Camera.main.transform.TransformDirection(movement) + transform.position;
        movement.y = transform.position.y;
        agent.destination = movement;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, movement);
    }
}
