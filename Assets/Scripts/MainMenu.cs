using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    //Buttons
    [SerializeField] private Button gameModeOneButton;
    [SerializeField] private Button gameModeTwoButton;
    [SerializeField] private Button statisticsButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameModeOneButton.onClick.AddListener(OpenGameModeOne);
        gameModeTwoButton.onClick.AddListener(OpenGameModeTwo);
        exitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenGameModeOne()
    {
        AkSoundEngine.StopAll();
        SceneManager.LoadSceneAsync(1);
    }

    public void OpenGameModeTwo()
    {
        AkSoundEngine.StopAll();
        SceneManager.LoadSceneAsync(2);
    }
}
