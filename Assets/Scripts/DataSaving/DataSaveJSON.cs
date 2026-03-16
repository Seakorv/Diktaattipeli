using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveData
{
    public List<DataSaveCorrect> CorrectAnswers;
    public List<DataSaveIncorrect> IncorrectAnswers;
    public int CorrectScore;
}

public class DataSaveJSON : MonoBehaviour
{
    private List<DataSaveCorrect> answerDataCorrect;
    private List<DataSaveIncorrect> answerDataIncorrect;

    void Start()
    {
        answerDataCorrect = DataSaving.dataSavingInstance.saveCorrectAnswers;
        answerDataIncorrect = DataSaving.dataSavingInstance.saveIncorrectAnswers;
    }

    public void SaveData()
    {
        string path = Application.persistentDataPath + "/SaveData.json";

        SaveData data;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            data = new SaveData();
            data.CorrectAnswers = new List<DataSaveCorrect>();
            data.IncorrectAnswers = new List<DataSaveIncorrect>();
        }

        data.CorrectAnswers.AddRange(answerDataCorrect);
        data.IncorrectAnswers.AddRange(answerDataIncorrect);

        //Saving only the highest score
        if (data.CorrectScore < GameManager.gameManagerInstance.CorrectCounter)
        {
            data.CorrectScore = GameManager.gameManagerInstance.CorrectCounter;
        }

        string newJson = JsonUtility.ToJson(data, true);

        File.WriteAllText(path, newJson);
    }

    public void LoadData()
    {
        
    }
}
