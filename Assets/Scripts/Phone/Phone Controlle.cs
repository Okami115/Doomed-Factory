using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PhoneControlle : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;

    [SerializeField] private bool LightOn;
    [SerializeField] private bool SpectOn;

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
    }

    public void HidePhone()
    {
        if (LightOn)
            AkSoundEngine.PostEvent("Play_SFX_Player_Interact_Phone_Screen_Lock",gameObject);
        
        LightOn = false;
        SpectOn = false;
        m_Animator.SetBool("Light", LightOn);
        m_Animator.SetBool("Spect", SpectOn);
        
    }
}
