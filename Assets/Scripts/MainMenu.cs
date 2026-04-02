using System;
using System.Collections;
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
    [SerializeField] private GameObject optionsPopUp;
    [SerializeField] private AK.Wwise.Event playMenuMusic;
    [SerializeField] private AK.Wwise.Event stopMenuMusic;

    private SaveGameData statisticsInformation;

    public void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(InitMenuMusic());
        Debug.Log("Hei");
        gameModeOneButton.onClick.AddListener(OpenGameModeOne);
        gameModeTwoButton.onClick.AddListener(OpenGameModeTwo);
        exitButton.onClick.AddListener(QuitGame);
        statisticsButton.onClick.AddListener(OpenStatistics);
        optionsButton.onClick.AddListener(OpenOptions);
    }

    IEnumerator InitMenuMusic()
    {
        yield return new WaitForSeconds(0.1f);

        AkBankLoader.akBankLoaderInstance.LoadSoundBanks();

        yield return new WaitForSeconds(0.1f);

        SetMenuMusic(true);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMenuMusic(bool onOff)
    {
        if (onOff) { playMenuMusic.Post(gameObject); }
        else { stopMenuMusic.Post(gameObject); }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenGameModeOne()
    {
        SetMenuMusic(false);
        SceneManager.LoadSceneAsync(2);
    }

    public void OpenGameModeTwo()
    {
        SetMenuMusic(false);
        SceneManager.LoadSceneAsync(3);
    }

    public void OpenOptions()
    {
        optionsPopUp.SetActive(true);
    }
    
    public void OpenStatistics()
    {
        statisticsInformation = DataSaveSystem.LoadData();
        if (statisticsInformation != null)
        {
            SetStatistics();    
        }
        statisticsPopUp.SetActive(true);
    }

    private void SetStatistics()
    {
        Debug.Log("High score gm one: " + statisticsInformation.HighScore[0].SaveScore);
        SetMostCorrectWrong();
        SetAverages();

        statisticsPopUp.GetComponent<StatisticsScript>().SetStatisticsScoreGmOne(statisticsInformation.HighScore[0].SaveScore);
        statisticsPopUp.GetComponent<StatisticsScript>().SetStatisticsScoreGmTwo(statisticsInformation.HighScore[1].SaveScore);
    }
    

    /// <summary>
    /// Reads the saved information and figures out which scale is answered most correct between both gamemodes
    /// </summary>
    /// <returns>The name of the most correct answered scale</returns>
    private void SetMostCorrectWrong()
    {
        string mostCorrectTest = "---";
        string mostWrongTest = "---";

        //First grouping the list by the correct scale names
        //then ordering them high to low where first element is the most amount of
        //correct answers.
        //Then getting the key = scale name for te var mostCorrect from the first element
        // mostCorrect will always be a string so its safe to put it in mostCorrectTest
        if (statisticsInformation.CorrectAnswers.Any())
        {
            var mostCorrect= statisticsInformation.CorrectAnswers
                .GroupBy(correct => correct.CorrectScale)
                .OrderByDescending(scale => scale.Count())
                .First().Key;

            mostCorrectTest = mostCorrect;
        }


        //First doing the same thing as above expect
        //we want to know the correct answer when player answered wrong, thats why wrong.CorrectScale
        //Then doing the same thing as above again
        if (statisticsInformation.IncorrectAnswers.Any())
        {
            var mostWrong = statisticsInformation.IncorrectAnswers
                .GroupBy(wrong => wrong.CorrectScale)
                .OrderByDescending(scale => scale.Count())
                .First().Key;
            
            mostWrongTest = mostWrong;
        }



        statisticsPopUp.GetComponent<StatisticsScript>().SetStatisticsMostCorrectWrong(mostCorrectTest, mostWrongTest);
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
            .LastOrDefault();
        
        var slowestScaleGmOne = scaleSpeedsGmOne
            .OrderByDescending(scale => scale.Value)
            .FirstOrDefault();

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
            .LastOrDefault();
        
        var slowestScaleGmTwo = scaleSpeedsGmTwo
            .OrderByDescending(scale => scale.Value)
            .FirstOrDefault();
        
        statisticsPopUp.GetComponent<StatisticsScript>().SetSpeedStatisticsGmOne(fastestScaleGmOne.Key, slowestScaleGmOne.Key);
        statisticsPopUp.GetComponent<StatisticsScript>().SetSpeedStatisticsGmTwo(fastestScaleGmTwo.Key, slowestScaleGmTwo.Key);
    }
}
