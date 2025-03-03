using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CamaraMovement : MonoBehaviour
{
    [Header("Init Variables")]
    [SerializeField] private GamePauseSO gamePauseSO;
    [SerializeField] private PlayerMovementNavMesh playerMovement;
    
    [Header("Cam Variables")]
    [SerializeField] private float SpeedRotation;
    [SerializeField] private Transform camera;

    [Header("Clamp Variables")]
    [SerializeField] private float clampToUp;
    [SerializeField] private float clampToDown;

    [Space]
    public float xRotation = 0;
    public float yRotation = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!gamePauseSO.isPlayPuzzle)
        {
            if (!playerMovement.CanMove)
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                yRotation += mouseX;
                yRotation = Mathf.Clamp(yRotation, -150, -30);

                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -30, 10);

                transform.rotation = Quaternion.Euler(0, yRotation, 0);
                camera.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            }
            else
            {
                if (!gamePauseSO.isPause)
                {
                    float mouseX = Input.GetAxis("Mouse X");
                    float mouseY = Input.GetAxis("Mouse Y");

                    yRotation += mouseX;

                    xRotation -= mouseY;
                    xRotation = Mathf.Clamp(xRotation, clampToDown, clampToUp);

                    if (Input.GetKey(KeyCode.J))
                    {
                        yRotation = 0;
                    }

                    transform.rotation = Quaternion.Euler(0, yRotation, 0);
                    camera.rotation = Quaternion.Euler(xRotation, yRotation, 0);
                }
            }
        }
    }
}
