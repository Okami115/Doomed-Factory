using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TutorialScreen : MonoBehaviour
{
    [SerializeField] private GameObject tutorialScreen;
    [SerializeField] private float startDuration;
    [SerializeField] private float endDuration;
    [SerializeField] private Image FadeImage;
    [FormerlySerializedAs("FadeStartGame")] [SerializeField] private mainFade mainFade;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(WaitForTheEnd());
        }
    }

    IEnumerator WaitForTheEnd()
    {
        float elapsedTime = 0f;

        while (FadeImage.color.a < 1)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Clamp01(elapsedTime / startDuration);

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, newAlpha);

            yield return null;
        }
        
        tutorialScreen.SetActive(false);
        mainFade.startFade();
    }

    IEnumerator WaitForTheStart()
    {
        float elapsedTime = 0f;

        while (FadeImage.color.a > 0)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Clamp01(1f - (elapsedTime / startDuration));

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, newAlpha);

            yield return null;
        }
    }

    public void StartTutorialButton()
    {
        tutorialScreen.SetActive(true);
        StartCoroutine(WaitForTheStart());
    }

    public void endTutorialButton()
    {
        StartCoroutine(WaitForTheEnd());
    }
}