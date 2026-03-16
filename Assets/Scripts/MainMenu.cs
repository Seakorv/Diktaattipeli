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
        SetAverages();
        statisticsPopUp.GetComponent<StatisticsScript>().SetStatisticsScore(statisticsInformation.HighScore[0].SaveScore, statisticsInformation.HighScore[1].SaveScore);
    }
    

    /// <summary>
    /// Reads the saved information and figures out which scale is answered most correct between both gamemodes
    /// </summary>
    /// <returns>The name of the most correct answered scale</returns>
    private void SetMostCorrectWrong()
    {
        //First grouping the list by the correct scale names
        //then ordering them high to low where first element is the most amount of
        //correct answers.
        //Then getting the key = scale name for te var mostCorrect from the first element
        var mostCorrect= statisticsInformation.CorrectAnswers
            .GroupBy(correct => correct.CorrectScale)
            .OrderByDescending(scale => scale.Count())
            .First().Key;

        //First doing the same thing as above expect
        //we want to know the correct answer when player answered wrong, thats why wrong.CorrectScale
        //Then doing the same thing as above again
        var mostWrong = statisticsInformation.IncorrectAnswers
            .GroupBy(wrong => wrong.CorrectScale)
            .OrderByDescending(scale => scale.Count())
            .First().Key;

        statisticsPopUp.GetComponent<StatisticsScript>().SetStatisticsMostCorrectWrong(mostCorrect, mostWrong);
    }

    /// <summary>
    /// Setting the fastest and the slowest scale. The function gets the scale as a key and makes the 
    /// answer values to a list. Then it takes the average speed of each key and sets the fastest and slowest
    /// for the statistics popup
    /// </summary>
    private void SetAverages()
    {
        //Filtering only game mode ones
        //Then grouping by scale name
        //then making them into a dictionary where:
        //Key is scale name, other element is a list of the answer speeds
        var scaleSpeedsGmOne = statisticsInformation.CorrectAnswers
            .Where(correct => correct.MyGameMode == 1)
            .GroupBy(correct => correct.CorrectScale)
            .ToDictionary(
                scale => scale.Key,
                scale => scale.Average(correct => correct.AnswerTime)
            );
        
        //Ordering them again. Last is the fastest value, first is the slowest
        var fastestScaleGmOne = scaleSpeedsGmOne
            .OrderByDescending(scale => scale.Value)
            .Last();
        
        var slowestScaleGmOne = scaleSpeedsGmOne
            .OrderByDescending(scale => scale.Value)
            .First();
        
        foreach (var scale in scaleSpeedsGmOne)
        {
            Debug.Log(scale.Key + " Average: " + scale.Value);
        }
        Debug.Log("Fastest scale gm one: " + fastestScaleGmOne);


        //Exactly the same things but for game mode two ones
        var scaleSpeedsGmTwo = statisticsInformation.CorrectAnswers
            .Where(correct => correct.MyGameMode == 2)
            .GroupBy(correct => correct.CorrectScale)
            .ToDictionary(
                scale => scale.Key,
                scale => scale.Average(correct => correct.AnswerTime)
            );
        
        var fastestScaleGmTwo = scaleSpeedsGmTwo
            .OrderByDescending(scale => scale.Value)
            .Last();
        
        var slowestScaleGmTwo = scaleSpeedsGmTwo
            .OrderByDescending(scale => scale.Value)
            .First();
        
        statisticsPopUp.GetComponent<StatisticsScript>().SetSpeedStatisticsGmOne(fastestScaleGmOne.Key, slowestScaleGmOne.Key);
        statisticsPopUp.GetComponent<StatisticsScript>().SetSpeedStatisticsGmTwo(fastestScaleGmTwo.Key, slowestScaleGmTwo.Key);
    }
}
