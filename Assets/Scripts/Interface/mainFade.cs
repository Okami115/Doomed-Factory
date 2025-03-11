using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainFade : MonoBehaviour
{
    [SerializeField] private float startGameDuration;
    [SerializeField] private ScrollImage credits;
    [SerializeField] private TutorialScreen tutorialScreen;
    [SerializeField] private Image FadeImage;

    private void OnEnable()
    {
        StartCoroutine(StartFade());
    }

    public void startFade()
    {
        StartCoroutine(StartFade());
    }

    public void playCreditsFade()
    {
        credits.StartCreditsButton();
        StartCoroutine(ReverseFade());
    }
    
    public void playTutorialFade()
    {
        tutorialScreen.StartTutorialButton();
        StartCoroutine(ReverseFade());
    }

    private IEnumerator StartFade()
    {
        float elapsedTime = 0f;

        FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, 1f);
        
        while (FadeImage.color.a > 0)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Clamp01(1f - (elapsedTime / startGameDuration));

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, newAlpha);

            yield return null;
        }
    }

    private IEnumerator ReverseFade()
    {
        float elapsedTime = 0f;
        
        while (FadeImage.color.a < 1)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Clamp01(elapsedTime / startGameDuration);

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, newAlpha);

            yield return null;
        }
    }
}
