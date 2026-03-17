using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameName;
    [SerializeField] private Button startButton;
    [SerializeField] private Button toMainMenuButton;

    void Awake()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        toMainMenuButton.onClick.AddListener(OnMainMenuClick);
    }

    void Start()
    {
        //GameModeOne.gameModeOneInstance.UpdateGenreState(CurrentGenreState.None);
    }

    private void OnStartButtonClick()
    {
        Debug.Log("Start klikattu");
        //GameModeOne.gameModeOneInstance.StartGame();
        //GameModeOne.gameModeOneInstance.UpdateGenreState(CurrentGenreState.EasySynth);
        GameManager.gameManagerInstance.SetFirstScaleState();
        GameManager.gameManagerInstance.ResetAnswerTimer();
        GameManager.gameManagerInstance.SetButtonsActive(true);
        this.gameObject.SetActive(false);
    }

    private void OnMainMenuClick()
    {
        AkUnitySoundEngine.StopAll();
        SceneManager.LoadSceneAsync(0);
    }

    public void SetPopUpGameName(string game)
    {
        gameName.text = game;
    }
}
