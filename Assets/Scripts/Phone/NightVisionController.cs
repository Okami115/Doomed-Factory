using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class NightVisionController : MonoBehaviour
{
    
    [SerializeField] private Color defaultLightColour;
    [SerializeField] private Color boostedLightColour;
 
    private bool isNightVisionEnabled;
 
    private PostProcessVolume volume;
 
    private void Start()
    {
        RenderSettings.ambientLight = defaultLightColour;
 
        volume = gameObject.GetComponent<PostProcessVolume>();
        volume.weight = 0;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNightVision();
            Debug.Log("NightVision");
        }
    }
 
    private void ToggleNightVision()
    {
        isNightVisionEnabled = !isNightVisionEnabled;
 
        if (isNightVisionEnabled)
        {
            RenderSettings.ambientLight = boostedLightColour;
            volume.weight = 1;
        }
        else
        {
            RenderSettings.ambientLight = defaultLightColour;
            volume.weight = 0;
        }
    }
}
