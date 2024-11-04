using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FlickLights : MonoBehaviour
{
    [SerializeField] private List<Light> _lights;
    [SerializeField] private bool startflashing;
    [SerializeField] private float minFlickTime;
    [SerializeField] private float maxFlickTime;
    [SerializeField] private float flickTime;
    private bool _startflashingCorrutine = false;

    public void SetStartFlashing(bool value) => startflashing = value;

    private void Update()
    {
        if (startflashing)
            if (!_startflashingCorrutine)
                StartCoroutine(Flickeringlight());
    }

    public IEnumerator Flickeringlight()
    {
        _startflashingCorrutine = true;
        flickTime = Random.Range(minFlickTime, maxFlickTime);
        yield return new WaitForSeconds(flickTime);
        foreach (Light _light in _lights)
        {
            _light.enabled = !_light.enabled;
        }
        yield return null;
        _startflashingCorrutine = false;
    }
}