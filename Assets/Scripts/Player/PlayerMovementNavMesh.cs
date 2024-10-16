using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementNavMesh : MonoBehaviour
{
    [Header("Init Variables")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private PlayerInputsReader _inputsReader;
    [SerializeField] private KeysEventChannel _doorInteraction;
    [SerializeField] private List<Keys> playerKeys;
    [SerializeField] private CamaraMovement cam;

    [Header("Movement Variables")]
    [SerializeField] private float RunSpeed;
    [SerializeField] private float WalkSpeed;
    [SerializeField] private float CrouchSpeed;
    [SerializeField] private Transform pivot;

    [Header("Camera Animate Variables")]
    [SerializeField] private float frequencyY;
    [SerializeField] private float amplitudeY;
    [SerializeField] private float frequencyX;
    [SerializeField] private float amplitudeX;

    [Header("Debug Variables")]
    [SerializeField] private Transform target;

    Vector3 movement = Vector3.zero;
    private float elapsedTime;
    private Vector3 originalCameraPosition;
    private Transform cameraTransform;
    public bool isTPOn = false;

    private void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        originalCameraPosition = cameraTransform.localPosition;
        _inputsReader.OnPlayerInteract += OnPlayerInteract;
    }

    private void OnDestroy()
    {
        _inputsReader.OnPlayerInteract -= OnPlayerInteract;
    }

    private void OnPlayerInteract()
    {
        _doorInteraction?.Invoke(playerKeys);
    }

    public void AddKey(Keys newKey)
    {
        playerKeys.Add(newKey);
    }

    public List<Keys> GetKeys()
    {
        return playerKeys;
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
                agent.speed = RunSpeed;
            }
            else
            {
                agent.speed = WalkSpeed;
            }

            agent.isStopped = false;
            movement += transform.position + (movement.normalized / 100);

            movement.y = pivot.position.y;

            RaycastHit hit;
            if (Physics.Raycast(movement, Vector3.down, out hit))
            {
                movement.y = hit.point.y + 0.1f;

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
                agent.speed = CrouchSpeed;
                Vector3 aux = new Vector3(cameraTransform.position.x, cameraTransform.position.y - 1, cameraTransform.position.z);

                cameraTransform.position = aux;
            }
        }

        if(isTPOn)
        {
            TPPlayer();
            isTPOn=false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(pivot.position, movement);
    }

    public void TPPlayer()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
        agent.destination = transform.position;
        movement = Vector3.zero;
        cam.yRotation = 0;
    }
}