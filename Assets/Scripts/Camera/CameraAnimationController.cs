using UnityEngine;

public class CameraAnimationController : MonoBehaviour
{
    public static CameraAnimationController Instance;
    private Animator menuAnimator;


    private void OnEnable()
    {
        Instance = this;
        menuAnimator = GetComponent<Animator>();
        GoToMainMenu();
    }

    public void GoToOptions()
    {
        menuAnimator.SetBool("OptionsPanel",true);
    }

    public void GoToCredits()
    {
        menuAnimator.SetBool("CreditsPanel",true);
    }

    public void GoToMainMenu()
    {
        menuAnimator.SetBool("OptionsPanel",false);
        menuAnimator.SetBool("CreditsPanel",false);
    }
}
