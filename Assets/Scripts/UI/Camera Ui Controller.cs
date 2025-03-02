using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraUiController : MonoBehaviour
{
    [SerializeField] private GameObject cameraRecCircle;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private RawImage cameraRec;
    [SerializeField] private List<GameObject> objectsLights;
    private float currentTime;
    private float flickTime = 1.5f;
    private bool _startflashingCorrutine = false;
    private bool lightEnabled = true;
    private bool alreadyPlayed = false;
    private bool alreadyPlayedStart = false;

    private void OnEnable()
    {
        if (!alreadyPlayedStart)
            StartCoroutine(StartCameraUi());
    }

    private void OnDisable()
    {
        lightEnabled = false;
        cameraRec.enabled = false;
        timeText.gameObject.SetActive(false);
        cameraRecCircle.SetActive(false);
        foreach (GameObject light in objectsLights)
        {
            light.SetActive(false);
        }
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

    public IEnumerator StartCameraUi()
    {
        yield return new WaitForSeconds(0.5f);
        cameraRec.enabled = true;
        cameraRecCircle.SetActive(true);
        timeText.gameObject.SetActive(true);
        lightEnabled = true;
        foreach (GameObject light in objectsLights)
        {
            light.SetActive(true);
        }
        alreadyPlayedStart = false;
        yield return null;
    }
}