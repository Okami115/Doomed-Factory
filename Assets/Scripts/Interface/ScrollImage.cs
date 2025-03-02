using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScrollImage : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private float duration;
    [SerializeField] private float startDuration;
    [SerializeField] private float endDuration;
    [SerializeField] private Image FadeImage;

    [SerializeField] private GameObject CreditsOBJ;

    private float speed;
    private bool StartScrolling;

    private Vector3 startPosition;

    void Awake()
    {
        startPosition = transform.position;
        speed = image.rectTransform.rect.height / duration;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartScrolling = false;
            StartCoroutine(WaitForTheEnd());
        }

        if (StartScrolling)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;

            if (transform.position.y > image.rectTransform.rect.height)
            {
                StartScrolling = false;
                StartCoroutine(WaitForTheEnd());
            }
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

        StartScrolling = false;
        CreditsOBJ.SetActive(false);
    }

    IEnumerator WaitForTheStart()
    {
        transform.position = startPosition;
        float elapsedTime = 0f;

        while (FadeImage.color.a > 0)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Clamp01(1f - (elapsedTime / startDuration));

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, newAlpha);

            yield return null;
        }

        StartScrolling = true;
    }

    public void StartCreditsButton()
    {
        CreditsOBJ.SetActive(true);
        StartCoroutine(WaitForTheStart());
    }
}