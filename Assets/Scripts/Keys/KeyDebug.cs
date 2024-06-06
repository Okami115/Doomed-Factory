using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class KeyDebug : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
    }
}
