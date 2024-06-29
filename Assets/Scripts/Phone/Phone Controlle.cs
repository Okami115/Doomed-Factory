using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PhoneControlle : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;

    [SerializeField] private bool LightOn;
    [SerializeField] private bool SpectOn;
    [SerializeField] private bool CameraOn;

    public void OnLight()
    {
      
        
        LightOn = !LightOn;
        m_Animator.SetBool("Light", LightOn);
        Debug.Log(LightOn);
        
        if (LightOn)
            AkSoundEngine.PostEvent("Play_SFX_Player_Interact_Phone_Light_On",gameObject);
        else
            AkSoundEngine.PostEvent("Play_SFX_Player_Interact_Phone_Light_Off",gameObject);
        
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

        if (SpectOn && CameraOn)
        {
            CameraOn = !CameraOn;
            m_Animator.SetBool("Camera", CameraOn);
        }
    }

    public void OnCamera()
    {
        CameraOn = !CameraOn;
        m_Animator.SetBool("Camera", CameraOn);

    }

    public void HidePhone()
    {
        if (LightOn)
            AkSoundEngine.PostEvent("Play_SFX_Player_Interact_Phone_Screen_Lock",gameObject);
        
        LightOn = false;
        SpectOn = false;
        CameraOn = false;
        m_Animator.SetBool("Light", LightOn);
        m_Animator.SetBool("Spect", SpectOn);
        m_Animator.SetBool("Camera", CameraOn);
    }
}
