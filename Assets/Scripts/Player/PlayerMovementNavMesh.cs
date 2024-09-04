using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovementNavMesh : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;
    [SerializeField] private PlayerInputsReader playerInputsReader;
    Vector3 movement = Vector3.zero;
    private float elapsedTime;
    [SerializeField] private float frequencyY;
    [SerializeField] private float amplitudeY;
    [SerializeField] private float frequencyX;
    [SerializeField] private float amplitudeX;
    private Vector3 originalCameraPosition;
    private Transform cameraTransform;

    private void Start()
    {
        playerInputsReader.OnPlayerMove += OnMove;

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void OnDestroy()
    {
        playerInputsReader.OnPlayerMove -= OnMove;    
    }

    private void OnMove(Vector2 direction)
    {
        movement = new Vector3(direction.x, 0, direction.y);
    }

    private void Update()
    {
        //movement = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            agent.speed = 15;
        }
        else
        {
            agent.speed = 10;
        }

        agent.isStopped = false;
        movement += transform.position + movement * 2;
        movement.y = transform.position.y / 2;
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
            agent.speed = 5;
            Vector3 aux = new Vector3(cameraTransform.position.x, cameraTransform.position.y / 2, cameraTransform.position.z);

            cameraTransform.position = aux;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, movement);
    }
}
