using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class FlickLights : MonoBehaviour
{
    [SerializeField] private List<Light> _lights;
    [SerializeField] private bool startflashing;
    [SerializeField] private float minFlickTime;
    [SerializeField] private float maxFlickTime;
    private float flickTime;
    private bool _startflashingCorrutine = false;
    private bool lightEnabled = true;
    private bool alreadyPlayed = false;

    private void OnEnable()
    {
        alreadyPlayed = false;
        lightEnabled = true;
        gameObject.SetActive(true);
    }

    public void SetStartFlashing(bool value) => startflashing = value;

    private void Update()
    {
        if (startflashing)
            if (!_startflashingCorrutine)
                StartCoroutine(Flickeringlight());
        if (lightEnabled)
        {
            if (!alreadyPlayed)
            {
                AkSoundEngine.PostEvent("Play_LighBulb_Hum", gameObject);
                alreadyPlayed = true;
            }
        }
        else
            AkSoundEngine.PostEvent("Stop_LighBulb_Hum", gameObject);
    }

    public IEnumerator Flickeringlight()
    {
        _startflashingCorrutine = true;
        bool lightEnabled = false;
        flickTime = Random.Range(minFlickTime, maxFlickTime);
        yield return new WaitForSeconds(flickTime);
        foreach (Light _light in _lights)
        {
            _light.enabled = !_light.enabled;
            lightEnabled = _light.enabled;
        }

        if (lightEnabled)
            AkSoundEngine.PostEvent("Play_LighBulb_Hum", gameObject);
        else
            AkSoundEngine.PostEvent("Stop_LighBulb_Hum", gameObject);
        yield return null;
        _startflashingCorrutine = false;
    }

    public void TurnLights(bool value)
    {
        foreach (Light _light in _lights)
        {
            _light.enabled = value;
            lightEnabled = value;
        }

        if (lightEnabled)
            alreadyPlayed = false;
    }

    public void ExplodeLights()
    {
        AkSoundEngine.PostEvent("Play_LighBulb_Drop", gameObject);
        AkSoundEngine.PostEvent("Stop_LighBulb_Hum", gameObject);
        alreadyPlayed = false;
        lightEnabled = false;
        startflashing = false;
        gameObject.SetActive(false);
    }
}