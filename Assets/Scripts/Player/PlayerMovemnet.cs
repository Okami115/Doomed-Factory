using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovemnet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerInputsReader _inputsReader;
    [SerializeField] private KeysEventChannel _doorInteraction;
    [SerializeField] private List<Keys> playerKeys;
    private Vector3 movePlayer;
    private Vector3 movement;

    public float amplitude = 0.001f; 
    [SerializeField] public float frequency = 1f;   
    public Transform cameraTransform; 

    private Vector3 originalCameraPosition;
    private float elapsedTime = 0f;

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

    private void OnPlayerMove(Vector3 obj)
    {
       // movement = obj;
    }

    private void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");
        
        
        Vector3 movement = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0.0f; 


        if (movement != Vector3.zero)
        {
            rb.AddForce(movement * speed);

            elapsedTime += Time.deltaTime;

            float oscillation = Mathf.Sin(elapsedTime * frequency) * 0.1f;

            Vector3 newCameraPosition = originalCameraPosition;
            newCameraPosition.y += oscillation;
            cameraTransform.localPosition = newCameraPosition;
        }
        else
        {
            if (elapsedTime > 0)
                elapsedTime -= Time.deltaTime;
            else
                elapsedTime = 0f;


            cameraTransform.localPosition = originalCameraPosition;
        }
    }   
}
