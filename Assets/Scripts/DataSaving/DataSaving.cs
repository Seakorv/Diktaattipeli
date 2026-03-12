using System;
using System.Collections.Generic;
using UnityEngine;


public class DataSaving : MonoBehaviour
{
    public static DataSaving dataSavingInstance;
    public List<DataSaveIncorrect> saveIncorrectAnswers = new List<DataSaveIncorrect>();
    public List<DataSaveCorrect> saveCorrectAnswers = new List<DataSaveCorrect>();

    void Awake()
    {
        dataSavingInstance = this;
    }

    public void CorrectSaving(Scale current, float answerTime)
    {
        DataSaveCorrect saveCorrect = new()
        {
            CorrectScale = current.ScaleName,
            AnswerTime = answerTime,
            MyGameMode = GameManager.gameManagerInstance.GetMyGameModeNumber()
        };
        
        saveCorrectAnswers.Add(saveCorrect);
    }

    public void IncorrectSaving(Scale current, Scale wrongScale, int currentScore)
    {
        DataSaveIncorrect saveIncorrect = new()
        {
            CorrectScale = current.ScaleName,
            WrongScale = wrongScale.ScaleName,
            CurrentScore = currentScore
        };

        saveIncorrectAnswers.Add(saveIncorrect);
    }

    public void PrintCorrectSavings()
    {
        Debug.Log("Gamemode: " + GameManager.gameManagerInstance.GetMyGameModeNumber());
        for (int i = 0; i < saveCorrectAnswers.Count; i++)
        {
            Debug.Log("Current scale: " + saveCorrectAnswers[i].CorrectScale + 
                    "\n Answer Time: " + saveCorrectAnswers[i].AnswerTime);
        }
    }

    public void PrintIncorrectSavings()
    {
        for (int i = 0; i < saveIncorrectAnswers.Count; i++)
        {
            Debug.Log("Current scale: " + saveIncorrectAnswers[i].CorrectScale + 
                    "\n Wrong answer: " + saveIncorrectAnswers[i].WrongScale + 
                    "\n Current Score: " + saveIncorrectAnswers[i].CurrentScore);
        }
    }
}
