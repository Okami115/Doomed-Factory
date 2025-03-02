using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndDoor : MonoBehaviour
{
    [SerializeField] private float endGameDuration;
    [SerializeField] private Image FadeImage;
    [SerializeField] private PlayerMovementNavMesh playerMovement;
    [SerializeField] private Transform taget;
    [SerializeField] private GameObject soundTaget;
    private bool coroutineRunning = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!coroutineRunning)
        { 
            playerMovement.CanMove = false;
            playerMovement.TPPlayer(taget);
            coroutineRunning = true;
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        float elapsedTime = 0f;
        AkSoundEngine.PostEvent("Play_mannequinFootSteps", soundTaget);
        yield return new WaitForSeconds(5.0f);
        AkSoundEngine.PostEvent("Play_EnzoGlitch", soundTaget);
        while (FadeImage.color.a < 1)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Clamp01(elapsedTime / endGameDuration);

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, newAlpha);

            yield return null;
        }

        coroutineRunning = false;
        SceneManager.LoadScene(0);
        AkSoundEngine.StopAll();
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
    }
}