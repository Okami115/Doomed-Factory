using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    [SerializeField] private float SpeedRotation;
    [SerializeField] private Transform camera;

    [SerializeField] private float MaxRotationCamera;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * SpeedRotation);
        camera.Rotate(Vector3.right, -mouseY * SpeedRotation);
    }
}
