using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFixLightIntencity : MonoBehaviour
{
    [SerializeField] private float muliplier;
    [SerializeField] private float maxDistance;
    [SerializeField] private Transform pivote;

    private Light light;
    private RaycastHit hit;
    private Camera mainCamera;
    void Start()
    {
        light = GetComponent<Light>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Physics.Raycast(pivote.position, pivote.forward * maxDistance, out hit))
        {
            light.intensity = Mathf.Lerp(light.intensity ,Vector3.Distance(pivote.position, hit.point) / muliplier, 0.1f);
        }
    }
}
