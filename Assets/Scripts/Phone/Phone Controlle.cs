using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneControlle : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;

    [SerializeField] private bool LightOn;
    [SerializeField] private bool SpectOn;

    public void OnLight()
    {
        LightOn = !LightOn;
        m_Animator.SetBool("Light", LightOn);

        if(LightOn && SpectOn)
        {
            SpectOn = false;
            m_Animator.SetBool("Spect", SpectOn);
        }
    }

    public void OnSpect()
    {
        SpectOn = !SpectOn;
        m_Animator.SetBool("Spect", SpectOn);
    }
}
