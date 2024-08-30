using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovemnet : MonoBehaviour
{
    [Header("Walk Variable")]
    [SerializeField] private float timeBetweenSteps;
    [SerializeField] private float speed;
    [SerializeField] private float Desacelerate;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerInputsReader _inputsReader;
    [SerializeField] private KeysEventChannel _doorInteraction;
    [SerializeField] private List<Keys> playerKeys;
    private Vector3 movePlayer;
    private Vector3 movement;

    [Header("Walk Animation")] [SerializeField]
    private float amplitudeY;

    [SerializeField] private float amplitudeX;
    [SerializeField] private float frequencyY;
    [SerializeField] private float frequencyX;

    public Transform cameraTransform;

    private Vector3 originalCameraPosition;
    private float elapsedTime = 0f;
    private bool corrutineRuning = false;

    private void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        originalCameraPosition = cameraTransform.localPosition;
        _inputsReader.OnPlayerMove += OnPlayerMove;
        _inputsReader.OnPlayerInteract += OnPlayerInteract;
    }

    private void OnDestroy()
    {
        _inputsReader.OnPlayerMove -= OnPlayerMove;
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

    private void OnPlayerMove(Vector3 obj)
    {
        // movement = obj;
    }

    private void Update()
    {
        float movimientoHorizontal = 0;
        float movimientoVertical = 0;


        Vector3 movement = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0.0f;


        if (Vector3.Distance(movement, Vector3.zero) > Vector3.kEpsilon)
        {
            //rb.AddForce(movement * speed);

            elapsedTime += Time.deltaTime;

            float oscillationY = Mathf.Sin(elapsedTime * frequencyY) * amplitudeY;
            float oscillationX = Mathf.Sin(elapsedTime * frequencyX) * amplitudeX;
            Vector3 newCameraPosition = originalCameraPosition;
            newCameraPosition.y += oscillationY * rb.velocity.magnitude;
            newCameraPosition.x += oscillationX * rb.velocity.magnitude;
            cameraTransform.localPosition = newCameraPosition;
        }
        else
        {
            elapsedTime = Mathf.LerpUnclamped(elapsedTime, 0, 2);

            rb.velocity = Vector3.Lerp(rb.velocity, movement, Desacelerate);

            cameraTransform.localPosition = originalCameraPosition;
        }
        
        if (Vector3.Distance(movement, Vector3.zero) > Vector3.kEpsilon)
            if (!corrutineRuning)
                StartCoroutine(PlayStepsSound(timeBetweenSteps));
    }

    public IEnumerator PlayStepsSound(float timeBetweenSteps)
    {
        corrutineRuning = true;
        Debug.Log("Time To Step Sound : " + timeBetweenSteps);
        yield return new WaitForSeconds(timeBetweenSteps);
        AkSoundEngine.PostEvent("Play_Player_FootSteps", gameObject);
        Debug.Log("Play_Player_FootSteps");
        yield return null;
        corrutineRuning = false;
    }
}