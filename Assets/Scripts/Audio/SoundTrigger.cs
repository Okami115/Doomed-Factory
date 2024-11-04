using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        Debug.LogError("OnCollisionEnter");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogError("OnTriggerEnter");
    }
}
