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
        GameManager.gameManagerInstance.StartGame();
        GameManager.gameManagerInstance.SetFirstScaleState();
        GameManager.gameManagerInstance.ResetAnswerTimer();
        GameManager.gameManagerInstance.SetButtonsActive(true);
        //ScaleNotes.scaleNotesInstance.SetScaleNoteAugments(new int[8]);
        //GameModeOne.gameModeOneInstance.UpdateGenreState(CurrentGenreState.EasySynth);
        this.gameObject.SetActive(false);  
    }

    private void OnMainMenuClick()
    {
        AkSoundEngine.StopAll();
        //AkSoundEngine.ClearBanks();
        SceneManager.LoadSceneAsync(1);
    }

    public void SetPoints(int points)
    {
        pointsText.text = $"Points: {points}";
    }
}
