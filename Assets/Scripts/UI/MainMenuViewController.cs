using UnityEngine;

/// <summary>
/// This class manages the main menu UI and provides methods to navigate to different scenes and open options, credits and how to play views.
/// </summary>
public class MainMenuViewController : MonoBehaviour
{
    [SerializeField]
    private OptionsViewController _OptionsViewPrefab; // Prefab for the options view.
    [SerializeField]
    private CreditsViewController _CreditsViewPrefab; // Prefab for the credits view.
    [SerializeField]
    private HowToPlayViewController _HowToPlayViewPrefab; // Prefab for the credits view.

    private OptionsViewController _optionsViewController; // Reference to the instantiated options view.
    private CreditsViewController _creditsViewController; // Reference to the instantiated credits view.
    private HowToPlayViewController _HowToPlayViewController; // Reference to the instantiated how to play view.

    /// <summary>
    /// This method is called to change the game scene when a menu option is selected.
    /// </summary>
    /// <param name="scene">The name of the scene to transition to.</param>
    public void ChangeScene(string scene)
    {
        // Load the specified scene.
        FlowSystem.Instance.TriggerFSMEvent(scene);
        //TravelSystem.Instance.SceneLoad(scene);
    }

    /// <summary>
    /// This method is called to open the options view.
    /// </summary>
    public void OpenOptions()
    {
        // Instantiate the options view prefab if not already instantiated.
        if (_optionsViewController) return;
        _optionsViewController = Instantiate(_OptionsViewPrefab);
    }

    /// <summary>
    /// This method is called to open the credits view.
    /// </summary>
    public void OpenCredits()
    {
        // Instantiate the credits view prefab if not already instantiated.
        if (_creditsViewController) return;
        _creditsViewController = Instantiate(_CreditsViewPrefab);
    }

    /// <summary>
    /// Opens the "How to Play" view if it is not already open.
    /// </summary>
    public void OpenHowToPlay() {
        // Check if the "HowToPlay" view is already instantiated.
        if (_HowToPlayViewController) return;

        // Instantiate the "HowToPlay" view if it is not already open.
        _HowToPlayViewController = Instantiate(_HowToPlayViewPrefab);
    }
}