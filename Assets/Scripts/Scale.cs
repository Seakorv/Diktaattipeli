using System;
using System.Data;
using System.Data.Common;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public string ScaleName { get; set; } = "";
    public int ID { get; set; } = 0;
    public Scale[] CloseScales { get; } = new Scale[4];
    private Scale thisScale;

    public Scale()
    {
        ID = 0;
        CloseScales = new Scale[4];
        ScaleName = "Testi";
    }

    public Scale(int id, String scaleName)
    {
        ID = id;
        ScaleName = scaleName;
        CloseScales = new Scale[4];
    }

    public void SetIDandName(int id, String scaleName)
    {
        ID = id;
        ScaleName = scaleName;
    }
    
    public void SetCloseScales(Scale closeOne, Scale closeTwo, Scale closeThree, Scale closeFour)
    {
        CloseScales[0] = closeOne;
        CloseScales[1] = closeTwo;
        CloseScales[2] = closeThree;
        CloseScales[3] = closeFour;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisScale = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
