using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour, IInteractable
{
    public string name;
    public int id;

    private PlayerMovemnet _playerMovement;
    private bool isPlayerInRange;

    private void Start()
    {
        _playerMovement = FindAnyObjectByType<PlayerMovemnet>();
    }

    public void ReadyToInteract(bool ans)
    {
        isPlayerInRange = ans;
    }

    public void Interact(List<Keys> keysList)
    {
        if (_playerMovement != null && isPlayerInRange)
        {
            _playerMovement.AddKey(this);
            transform.position = new Vector3(-10, -10, -10);
        }
    }
}
