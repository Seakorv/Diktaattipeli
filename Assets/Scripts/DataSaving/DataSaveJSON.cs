using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSaveJSON : MonoBehaviour
{
    private DataSaving answerData;

    void Start()
    {
        answerData = DataSaving.dataSavingInstance;
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(answerData);
        Debug.Log(json);

        using(StreamWriter writer = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json"))
        {
            writer.Write(json);
        }
    }

    public void LoadData()
    {
        
    }
}
