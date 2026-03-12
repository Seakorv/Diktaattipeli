using System;
using System.Collections.Generic;
using UnityEngine;


public class DataSaving : MonoBehaviour
{
    public static DataSaving dataSavingInstance;
    private List<DataSaveIncorrect> saveIncorrectAnswers = new List<DataSaveIncorrect>();
    private List<DataSaveCorrect> saveCorrectAnswers = new List<DataSaveCorrect>();

    void Awake()
    {
        dataSavingInstance = this;
    }

    public void CorrectSaving(Scale current, float answerTime)
    {
        DataSaveCorrect saveCorrect = gameObject.AddComponent<DataSaveCorrect>();

        saveCorrect.MyCurrent = current;
        saveCorrect.AnswerTime = answerTime;

        saveCorrectAnswers.Add(saveCorrect);
    }

    public void IncorrectSaving(Scale current, Scale wrongScale, int currentScore)
    {
        DataSaveIncorrect saveIncorrect = gameObject.AddComponent<DataSaveIncorrect>();
        saveIncorrect.MyCurrent = current;
        saveIncorrect.WrongScale = wrongScale;
        saveIncorrect.CurrentScore = currentScore;

        saveIncorrectAnswers.Add(saveIncorrect);
    }

    public void PrintCorrectSavings()
    {
        Debug.Log("Gamemode: " + GameManager.gameManagerInstance.GetMyGameModeNumber());
        for (int i = 0; i < saveCorrectAnswers.Count; i++)
        {
            Debug.Log("Current scale: " + saveCorrectAnswers[i].MyCurrent.ScaleName + 
                    "\n Answer Time: " + saveCorrectAnswers[i].AnswerTime);
        }
    }

    public void PrintIncorrectSavings()
    {
        for (int i = 0; i < saveIncorrectAnswers.Count; i++)
        {
            Debug.Log("Current scale: " + saveIncorrectAnswers[i].MyCurrent.ScaleName + 
                    "\n Wrong answer: " + saveIncorrectAnswers[i].WrongScale.ScaleName + 
                    "\n Current Score: " + saveIncorrectAnswers[i].CurrentScore);
        }
    }
}
