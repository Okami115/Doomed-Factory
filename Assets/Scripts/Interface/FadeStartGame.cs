using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeStartGame : MonoBehaviour
{
    [SerializeField] private float startGameDuration;
    private void OnEnable()
    {
        StartCoroutine(StartFade());
    }

    IEnumerator StartFade()
    {
        float elapsedTime = 0f;
        Image FadeImage = GetComponent<Image>();

        FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, 1f);
        
        while (FadeImage.color.a > 0)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Clamp01(1f - (elapsedTime / startGameDuration));

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, newAlpha);

            yield return null;
        }
    }
}
