using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadButton : PhoneButton
{
    [SerializeField] private int sceneBuildIndex;
    [SerializeField] private float waitTime;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        
        if (isMouseInside)
        {
            StartCoroutine(LoadScene());
        }
    }
    public IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
