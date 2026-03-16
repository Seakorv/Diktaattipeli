using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveGameData
{
    public List<DataSaveCorrect> CorrectAnswers = new List<DataSaveCorrect>();
    public List<DataSaveIncorrect> IncorrectAnswers = new List<DataSaveIncorrect>();
    public DataSaveHighScore[] HighScore = new DataSaveHighScore[2];
}

public static class DataSaveSystem
{
    private static string path = Application.persistentDataPath + "/SaveData.json";
    
    public static void SaveData()
    {
        SaveGameData data;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveGameData>(json);
        }
        else
        {
            data = new SaveGameData();
            data.CorrectAnswers = new List<DataSaveCorrect>();
            data.IncorrectAnswers = new List<DataSaveIncorrect>();
        }

        data.CorrectAnswers.AddRange(DataSaving.dataSavingInstance.saveCorrectAnswers);
        data.IncorrectAnswers.AddRange(DataSaving.dataSavingInstance.saveIncorrectAnswers);

        int currentGameMode = DataSaving.dataSavingInstance.saveHighScore.CurrentGameMode;
        int score = DataSaving.dataSavingInstance.saveHighScore.SaveScore;

        switch (currentGameMode)
        {
            case 1:
                if (data.HighScore[0] == null || data.HighScore[0].SaveScore < score )
                {
                    data.HighScore[0] = DataSaving.dataSavingInstance.saveHighScore;
                }
                break;
            case 2:
                if (data.HighScore[1] == null || data.HighScore[1].SaveScore < score )
                {
                    data.HighScore[1] = DataSaving.dataSavingInstance.saveHighScore;
                }
                break;
        }

        string newJson = JsonUtility.ToJson(data, true);

        File.WriteAllText(path, newJson);

        Debug.Log("Answer information saved to: " + path);
    }

    public static SaveGameData LoadData()
    {
        if (!File.Exists(path))
        {
            Debug.Log("Save file not found");
            return null;
        }

        string json = File.ReadAllText(path);

        SaveGameData data = JsonUtility.FromJson<SaveGameData>(json);

        Debug.Log("Answer information loaded.");

        return data;
    }
}