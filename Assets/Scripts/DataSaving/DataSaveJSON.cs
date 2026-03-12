using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<DataSaveCorrect> correctAnswers;
    public List<DataSaveIncorrect> incorrectAnswers;
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
        string jsonCorrect = JsonUtility.ToJson(answerDataCorrect);
        string jsonIncorrect = JsonUtility.ToJson(answerDataIncorrect);

        SaveData data = new SaveData();
        data.correctAnswers = answerDataCorrect;
        data.incorrectAnswers = answerDataIncorrect;

        string json = JsonUtility.ToJson(data, true);
        
        for (int i = 0; i < answerDataCorrect.Count; i++)
        {
            Debug.Log(JsonUtility.ToJson(answerDataCorrect[i]));
        }

        for (int i = 0; i < answerDataIncorrect.Count; i++)
        {
            Debug.Log(JsonUtility.ToJson(answerDataIncorrect[i]));
        }

        using(StreamWriter writer = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            writer.Write(json);
        }
    }

    public void LoadData()
    {
        
    }
}
