using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<DataSaveCorrect> correctAnswers;
    public List<DataSaveIncorrect> incorrectAnswers;
    public int correctScore;
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
            data.correctAnswers = new List<DataSaveCorrect>();
            data.incorrectAnswers = new List<DataSaveIncorrect>();
        }

        data.correctAnswers.AddRange(answerDataCorrect);
        data.incorrectAnswers.AddRange(answerDataIncorrect);

        //Saving only the highest score
        if (data.correctScore < GameManager.gameManagerInstance.CorrectCounter)
        {
            data.correctScore = GameManager.gameManagerInstance.CorrectCounter;
        }

        string newJson = JsonUtility.ToJson(data, true);

        File.WriteAllText(path, newJson);
    }

    public void LoadData()
    {
        
    }
}
