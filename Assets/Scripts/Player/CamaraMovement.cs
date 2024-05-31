﻿using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    [SerializeField] private float SpeedRotation;
    [SerializeField] private Transform camera;

    private float xRotation = 0;
    private float yRotation = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        camera.rotation = Quaternion.Euler(xRotation, yRotation, 0);

    }
}
