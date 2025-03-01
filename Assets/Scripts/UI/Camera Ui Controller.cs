using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraUiController : MonoBehaviour
{
    [SerializeField] private GameObject cameraRecCircle;
    [SerializeField] private TextMeshProUGUI timeText;
    private float currentTime;
    private float flickTime = 1.5f;
    private bool _startflashingCorrutine = false;
    private bool lightEnabled = true;
    private bool alreadyPlayed = false;

    private void OnEnable()
    {
        alreadyPlayed = false;
        lightEnabled = true;
        cameraRecCircle.SetActive(true);
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            if (!_startflashingCorrutine)
                StartCoroutine(Flickeringlight());
        }

        currentTime = Time.timeSinceLevelLoad;
        DisplayTime(currentTime);
    }
    
    void DisplayTime(float timeToDisplay)
    {
        float hours = Mathf.FloorToInt(timeToDisplay / 3600);
        float minutes = Mathf.FloorToInt((timeToDisplay % 3600) / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        
        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    public IEnumerator Flickeringlight()
    {
        _startflashingCorrutine = true;
        yield return new WaitForSeconds(flickTime);
        cameraRecCircle.SetActive(false);
        yield return new WaitForSeconds(flickTime);
        cameraRecCircle.SetActive(true);
        yield return null;
        _startflashingCorrutine = false;
    }
}