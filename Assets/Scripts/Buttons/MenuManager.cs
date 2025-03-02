using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Image FadeImage;
    [SerializeField] private float startGameDuration;
    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void PlayGame()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        float elapsedTime = 0f;

        while (FadeImage.color.a < 1)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Clamp01(elapsedTime / startGameDuration);

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, newAlpha);

            yield return null;
        }
        
        SceneManager.LoadScene(1);
    }

}
