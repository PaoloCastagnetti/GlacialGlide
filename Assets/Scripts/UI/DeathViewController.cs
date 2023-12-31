using TMPro;
using UnityEngine;

/// <summary>
/// This class manages the user interface for the death view and handles scene transitions upon player death.
/// It should be attached to a GameObject as a MonoBehaviour script.
/// </summary>
public class DeathViewController : MonoBehaviour
{
    [SerializeField]
    private int _Points; // The current points earned by the player.

    [SerializeField]
    private TextMeshProUGUI _PointsValue; // The UI element that displays the points value.

    /// <summary>
    /// Initializes the game state upon start, including setting the points display and pausing the game.
    /// </summary>
    private void Start() {
        // Set text for the points display based on the current points from GameMaster.
        _Points = GameMaster.Instance.getPoints();
        _PointsValue.SetText(_Points.ToString());

        // Pause the game upon death.
        GameMaster.Instance.setPause(true);

        // Stop the game's background music.
        AudioSystem.Instance.StopMusic();
    }

    /// <summary>
    /// This method is called to change the game scene and reset game parameters upon player death.
    /// </summary>
    /// <param name="scene">The name of the scene to transition to.</param>
    public void ChangeScene(string scene)
    {
        // Reset game parameters.
        GameMaster.Instance.setHearts(3);
        GameMaster.Instance.setPause(false);
        GameMaster.Instance.setPoints(0);
        GameMaster.Instance.SetStartingSpeed();

        // Load the specified scene.
        //TravelSystem.Instance.SceneLoad(scene);
        FlowSystem.Instance.TriggerFSMEvent(scene);
    }
}
