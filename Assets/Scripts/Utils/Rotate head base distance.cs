using UnityEngine;

public class Rotateheadbasedistance : MonoBehaviour
{
   [Header("Rotation config")]
   [SerializeField] private float rotationSpeed;
   [SerializeField] private float DetectionDistance;

   [Header("Player variable")]
   [SerializeField] private GameObject head;
   [SerializeField] private GameObject player;
    
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, head.transform.position);

        if (distance < DetectionDistance)
        {
            Debug.Log($"{gameObject.name} is looking at {player.gameObject.name}");
            
            // Calcula la dirección hacia el player
            Vector3 directionToPlayer = player.transform.position - head.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, head.transform.up);

            // Rota suavemente hacia el player
            head.transform.rotation = Quaternion.Slerp(head.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            head.transform.rotation = new Quaternion(0, head.transform.rotation.y, 0, head.transform.rotation.w);
        }
        else
        {
            // Restaura la rotación inicial
            Quaternion rotation = head.transform.rotation;
            rotation.eulerAngles = Vector3.Slerp(rotation.eulerAngles, Vector3.zero, rotationSpeed * Time.deltaTime);
            head.transform.rotation = rotation;
            Debug.Log($"{head.gameObject.name} not looking at any player : rotation is {head.transform.rotation}");
        }
    }
}
