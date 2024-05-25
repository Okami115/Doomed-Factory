using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    private float _timeBetweenSteps;
    private Vector3 _movePlayer;
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
        
        if (rb.velocity != Vector3.zero && _timeBetweenSteps < 0.0f)
        {
            AkSoundEngine.PostEvent("Play_Player_FootSteps",gameObject);
            _timeBetweenSteps = 0.5f;
        }
        else
        {
            _timeBetweenSteps -= Time.deltaTime;
        }
    }

    private void PlayerMove(Vector3 move)
    {
        _movePlayer = move;
    }
}
