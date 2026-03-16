using System;
using System.Collections.Generic;
using System.Linq;
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

    private SaveGameData statisticsInformation;

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
        statisticsInformation = DataSaveSystem.LoadData();
        SetStatistics();
        statisticsPopUp.SetActive(true);
    }

    private void SetStatistics()
    {
        Debug.Log("High score gm one: " + statisticsInformation.HighScore[0].SaveScore);
        SetMostCorrectWrong();
        statisticsPopUp.GetComponent<StatisticsScript>().SetStatisticsScore(statisticsInformation.HighScore[0].SaveScore, statisticsInformation.HighScore[1].SaveScore);
    }
    

    /// <summary>
    /// Reads the saved information and figures out which scale is answered most correct between both gamemodes
    /// </summary>
    /// <returns>The name of the most correct answered scale</returns>
    private void SetMostCorrectWrong()
    {
        //Grouping by scale and getting the amounts of the scales.
        var scaleCounts = statisticsInformation.CorrectAnswers
            .GroupBy(cor => cor.CorrectScale)
            .ToDictionary(scale => scale.Key, scale => scale.Count());

        statisticsPopUp.GetComponent<StatisticsScript>().SetStatisticsMostCorrectWrong(scaleCounts.Keys.Max(), scaleCounts.Keys.Min());
    }
}
