using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementNavMesh : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform pivot;
    Vector3 movement = Vector3.zero;
    private float elapsedTime;
    [SerializeField] private float speedWalking;
    [SerializeField] private float speedRunning;
    [SerializeField] private float speedCrouching;
    [SerializeField] private float frequencyY;
    [SerializeField] private float amplitudeY;
    [SerializeField] private float frequencyX;
    [SerializeField] private float amplitudeX;
    private Vector3 originalCameraPosition;
    private Transform cameraTransform;

    private void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        originalCameraPosition = cameraTransform.localPosition;
    }

    private void Update()
    {
        movement = Vector3.zero;

        bool anyKey = false;

        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward;
            anyKey = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement += transform.forward * -1;
            anyKey = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement += transform.right * -1;
            anyKey = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right;
            anyKey = true;
        }

        if (!anyKey)
        {
            agent.destination = transform.position;
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                agent.speed = speedRunning;
            }
            else
            {
                agent.speed = speedWalking;
            }

            agent.isStopped = false;

            movement += transform.position + movement;
            movement.y = pivot.position.y;

            RaycastHit hit;
            if (Physics.Raycast(movement, Vector3.down, out hit))
            {
                movement.y = hit.point.y + 1;

            }
            agent.destination = movement;

            elapsedTime += Time.deltaTime;

            float oscillationY = Mathf.Sin(elapsedTime * frequencyY) * amplitudeY;
            float oscillationX = Mathf.Sin(elapsedTime * frequencyX) * amplitudeX;
            Vector3 newCameraPosition = originalCameraPosition;
            newCameraPosition.y += oscillationY * agent.velocity.magnitude;
            newCameraPosition.x += oscillationX * agent.velocity.magnitude;
            cameraTransform.localPosition = newCameraPosition;

            if (Input.GetKey(KeyCode.LeftControl))
            {
                agent.speed = speedCrouching;
                Vector3 aux = new Vector3(cameraTransform.position.x, cameraTransform.position.y / 2, cameraTransform.position.z);

                cameraTransform.position = aux;
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(pivot.position, movement);
    }
}