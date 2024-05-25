using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ArmController : MonoBehaviour
{
    [SerializeField] private float SpeedRotation;
    [SerializeField] private Vector3 rotation = Vector3.zero;
    private const string xAxis = "Mouse X";
    private const string yAxis = "Mouse Y";
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform playerArm;
    
    [Range(0.1f, 9f)][SerializeField] private float sensitivity = 2.0f;
    [Range(0f, 90f)][SerializeField] private float xRotationLimit = 88.0f;
    [Range(0f, 90f)][SerializeField] private float yRotationLimitTop = 88.0f;
    [Range(0f, 90f)][SerializeField] private float yRotationLimitBot = 88.0f;
    [Range(0f, 90f)][SerializeField] private float zRotationLimit = 0.01f;

    [SerializeField] private float MaxRotationCamera;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //float mouseX = Input.GetAxis("Mouse X");
        //float mouseY = Input.GetAxis("Mouse Y");
        //playerArm.Rotate(Vector3.up, mouseX * SpeedRotation);
        //playerCamera.transform.Rotate(Vector3.right, -mouseY * SpeedRotation);
        
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        //rotation.x = Mathf.Clamp( rotation.x, -xRotationLimit, xRotationLimit);
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
        //rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        rotation.z = Mathf.Clamp(transform.localRotation.z,-zRotationLimit, zRotationLimit);
        Quaternion xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        Quaternion yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);
        Quaternion zQuat = Quaternion.AngleAxis(rotation.z, Vector3.back);

        playerArm.localRotation = xQuat * yQuat * zQuat;
        
        if (rotation.x >= xRotationLimit)
            transform.Rotate(Vector3.up,  rotation.x * SpeedRotation * Time.deltaTime);
        if (rotation.x <= -xRotationLimit)
            transform.Rotate(Vector3.up,  rotation.x * SpeedRotation * Time.deltaTime);
        
        if (rotation.y >= -yRotationLimitTop)
            transform.Rotate(Vector3.right,  rotation.y * SpeedRotation * Time.deltaTime);
        if (rotation.y <= -yRotationLimitBot)
            transform.Rotate(Vector3.right,  -rotation.y * SpeedRotation * Time.deltaTime);
    }
}
