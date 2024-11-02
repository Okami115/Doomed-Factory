using UnityEngine;
using UnityEngine.UI;

public class TriggerToTP : MonoBehaviour
{
    int counter = 0;
    [SerializeField] private PlayerMovementNavMesh player;
    [SerializeField] private Image background;
    [SerializeField] private GameObject Loop;

    private void OnCollisionEnter(Collision collision)
    {
        counter++;

        if((counter % 2) == 0)
        {
            Loop.SetActive(true);
            player.isTPOn = true;
            background.color = new Color(0, 0, 0, 255);
            Destroy(this.gameObject);
        }
    }
}
