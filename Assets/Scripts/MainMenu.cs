using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*[Serializable]
public class correctAnswers
{
    
}*/

public class MainMenu : MonoBehaviour
{

    //Buttons
    [SerializeField] private Button gameModeOneButton;
    [SerializeField] private Button gameModeTwoButton;
    [SerializeField] private Button statisticsButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject statisticsPopUp;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameModeOneButton.onClick.AddListener(OpenGameModeOne);
        gameModeTwoButton.onClick.AddListener(OpenGameModeTwo);
        exitButton.onClick.AddListener(QuitGame);
        statisticsButton.onClick.AddListener(OpenStatistics);
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
        AkUnitySoundEngine.StopAll();
        SceneManager.LoadSceneAsync(1);
    }

    public void OpenGameModeTwo()
    {
        AkUnitySoundEngine.StopAll();
        SceneManager.LoadSceneAsync(2);
    }
    
    public void OpenStatistics()
    {
        statisticsPopUp.SetActive(true);
    }
}
