using UnityEngine;

public class PickItems : MonoBehaviour
{
    [SerializeField] private GameObject menssage;
    [SerializeField] private float rangeToActivate;

    private RaycastHit hit;
    private IInteractable obj = null;

    private void Update()
    {
        Pickitem();
    }
    private void Pickitem()
    {
        Camera mainCamera = Camera.main;

        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, rangeToActivate))
        {
            if (hit.transform.gameObject.TryGetComponent<IInteractable>(out obj))
            {
                menssage.SetActive(true);
                obj.ReadyToInteract(true);
            }
            else
            {
                menssage.SetActive(false);
                if (obj != null)
                {
                    obj.ReadyToInteract(false);
                    obj = null;
                }
            }
        }
        else
        {
            menssage.SetActive(false);
        }
    }
}
