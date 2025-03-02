using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndDoor : MonoBehaviour
{
    [SerializeField] private float endGameDuration;
    [SerializeField] private Image FadeImage;
    
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(EndGame());
    }
    
    IEnumerator EndGame()
    {
        float elapsedTime = 0f;

        while (FadeImage.color.a < 1)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Clamp01(elapsedTime / endGameDuration);

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, newAlpha);

            yield return null;
        }
        
        SceneManager.LoadScene(0);
        AkSoundEngine.StopAll();
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
    }
}
