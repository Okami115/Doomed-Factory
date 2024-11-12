using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sprite),typeof(string),typeof(string))]
public class Keys : MonoBehaviour, IInteractable
{
    public string name;
    public string description;
    public int id;
    [SerializeField] private List<GameObject> menssage;
    public Sprite KeyImage;

    private PlayerMovementNavMesh _playerMovement;
    private bool isPlayerInRange;
    private bool alreadyPicked;

    private void Start()
    {
        _playerMovement = FindAnyObjectByType<PlayerMovementNavMesh>();
    }

    public void ReadyToInteract(bool ans)
    {
        isPlayerInRange = ans;
    }

    public GameObject GetMsg()
    {
        return menssage[0];
    }

    public void Interact(List<Keys> keysList)
    {
        if (_playerMovement != null && isPlayerInRange)
        {
            _playerMovement.AddKey(this);
            transform.position = new Vector3(-10, -10, -10);

            if (!alreadyPicked)
            {
                alreadyPicked = !alreadyPicked;
                AkSoundEngine.PostEvent("Play_KeyPickUp", gameObject);
            }
        }
    }
}