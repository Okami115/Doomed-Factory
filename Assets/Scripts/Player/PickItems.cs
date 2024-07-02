using UnityEngine;

public class PickItems : MonoBehaviour
{
    [SerializeField] private GameObject menssage;
    [SerializeField] private float rangeToActivate;

    private RaycastHit hit;
    private IInteractable obj = null;
    private IInteractable lastObj = null;

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
                if(lastObj != obj)
                {
                    if(lastObj != null)
                    {
                        lastObj.ReadyToInteract(false);
                        lastObj = null;
                    }

                    menssage.SetActive(true);
                    obj.ReadyToInteract(true);


                    lastObj = obj;
                }
            }
            else
            {
                menssage.SetActive(false);

                if (lastObj != null)
                {
                    lastObj.ReadyToInteract(false);
                    lastObj = null;
                }
            }
        }
        else
        {
            menssage.SetActive(false);

            if (lastObj != null)
            {
                lastObj.ReadyToInteract(false);
                lastObj = null;
            }
        }
    }
}
