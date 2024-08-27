using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayButton : PhoneButton
{
    [SerializeField] private Animator _camAnimator;
    [SerializeField] private Animator _doorAnimator;
    [SerializeField] private int sceneBuildIndex;
    [SerializeField] private float waitTime;
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (isMouseInside)
        {
            _camAnimator.SetBool("Play",true);
            _doorAnimator.SetTrigger("Open");
            StartCoroutine(LoadScene());
        }

        
    }

    public IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
    }
}
