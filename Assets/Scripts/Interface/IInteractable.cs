using UnityEngine;

public interface IInteractable
{
    public abstract void ReadyToInteract(bool ans);
    public abstract GameObject GetMsg();
}
