using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerMovementNavMesh : MonoBehaviour
{
    [Header("Init Variables")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private PlayerInputsReader _inputsReader;
    [SerializeField] private KeysEventChannel _doorInteraction;
    [SerializeField] private List<Keys> playerKeys;
    [SerializeField] private LayerMask ignoreLayer;

    [Header("Movement Variables")]
    //[SerializeField] private float RunSpeed;
    [SerializeField] private float WalkSpeed;
    //[SerializeField] private float CrouchSpeed;
    [SerializeField] private Transform pivot;
    [SerializeField] private Rigidbody rigidbody;
    private bool _movementCorrutineRuning = false;

    [Header("Camera Animate Variables")]
    [SerializeField] private CamaraMovement cam;
    [SerializeField] private float frequencyY;
    [SerializeField] private float amplitudeY;
    [SerializeField] private float frequencyX;
    [SerializeField] private float amplitudeX;
    [SerializeField] private Image background;
    [SerializeField] private float multiplierTrancition;
    [SerializeField] private Transform cameraTransform;
    //[SerializeField] private Transform cameraTransformCrouch;

    [Header("Debug Variables")]
    [SerializeField] private Transform target;

    Vector3 movement = Vector3.zero;
    private float elapsedTime;
    private Vector3 originalCameraPosition;
    public bool isTPOn = false;

    private void Start()
    {
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
            rigidbody.velocity = Vector3.zero;
            cameraTransform.localPosition = originalCameraPosition;
        }
        else
        {
            float footstepsDelay = 0.5f;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //agent.speed = RunSpeed;
                //footstepsDelay = 0.4f;
            }
            else
            {
                agent.speed = WalkSpeed;
                footstepsDelay = 0.5f;
            }

            if (!_movementCorrutineRuning)
                StartCoroutine(PlayWalkSound( footstepsDelay));

            agent.isStopped = false;
            movement += transform.position + (movement.normalized / 100);

            movement.y = pivot.position.y;

            RaycastHit hit;
            if (Physics.Raycast(movement, Vector3.down, out hit, Mathf.Infinity, ~ignoreLayer))
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

        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            //    agent.speed = CrouchSpeed;
            //    cameraTransform.position = cameraTransformCrouch.position;
        }

        if (isTPOn)
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
        agent.Warp(target.position);
        movement = Vector3.zero;
        cam.yRotation = 0;
        StartCoroutine(FadeBackground());
    }

    public IEnumerator FadeBackground()
    {
        Color bgColor = background.color;

        while (bgColor.a > 0)
        {
            float newAlpha = bgColor.a - (Time.deltaTime * multiplierTrancition);

            newAlpha = Mathf.Clamp01(newAlpha);

            background.color = new Color(bgColor.r, bgColor.g, bgColor.b, newAlpha);

            bgColor = background.color;

            yield return null;
        }

        background.color = new Color(bgColor.r, bgColor.g, bgColor.b, 0);
    }
    public IEnumerator PlayWalkSound(float waitTime)
    {
        _movementCorrutineRuning = true;
        yield return new WaitForSeconds(waitTime);
        AkSoundEngine.PostEvent("Play_Player_FootSteps", gameObject);
        yield return null;
        _movementCorrutineRuning = false;
    }
}