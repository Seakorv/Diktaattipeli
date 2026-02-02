using TMPro;
using UnityEngine;
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
        //GameModeOne.gameModeOneInstance.StartGame();
        GameModeOne.gameModeOneInstance.UpdateGenreState(CurrentGenreState.EasySynth);
        this.gameObject.SetActive(false);
    }

    private void OnMainMenuClick()
    {
        Debug.Log("Pitäisi sulkea peli ja mennä main menuun");
    }

    public void SetPopUpGameName(string game)
    {
        gameName.text = game;
    }
}
