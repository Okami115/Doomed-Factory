using UnityEngine;

public class PlayerMovemnet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    private Vector3 movePlayer;
    private void Start()
    {
        PlayerInputsRead.Moving += PlayerMove;
    }

    private void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");


        Vector3 movimiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);
        movimiento = Camera.main.transform.TransformDirection(movimiento);
        movimiento.y = 0.0f; 

        rb.AddForce(movimiento * speed);
    }   

    private void PlayerMove(Vector3 move)
    {
        movePlayer = move;
    }
}
