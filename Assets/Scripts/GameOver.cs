using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button toMainMenuButton;

    void Awake()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        toMainMenuButton.onClick.AddListener(OnMainMenuClick);
    }

    private void OnStartButtonClick()
    {
        GameModeOne.gameModeOneInstance.StartGame();
        GameModeOne.gameModeOneInstance.SetFirstScaleState();
        //GameModeOne.gameModeOneInstance.UpdateGenreState(CurrentGenreState.EasySynth);
        this.gameObject.SetActive(false);  
    }

    private void OnMainMenuClick()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void SetPoints(int points)
    {
        pointsText.text = $"Points: {points}";
    }
}
