using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private int myNumber;
    [SerializeField] private string myName;
    [SerializeField] private Button myButton;
    [SerializeField] private TextMeshProUGUI myText;


    //[SerializeField] private  myScaleName;
    public bool IsCorrect { get; set; } = false;
    public CurrentScaleState ButtonScaleState { get; set; }
    private Scale myScaleObject;

    void Start()
    {
        //SetButtonName();
        //SetButtonText();
        Debug.Log(myButton.name);
        myButton.onClick.AddListener(TaskOnClick);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void TaskOnClick()
    {
        Random rand = new();
        //Debug.Log(rand.Next(0, 4));
        if (!IsCorrect)
        {
            Debug.Log("Väärin!");
            GameManager.gameManagerInstance.UpdatePointCounters(false);
            GameManager.gameManagerInstance.FromIncorrectButton(myScaleObject);
        }
        else
        {
            Debug.Log("Oikein!");
            GameManager.gameManagerInstance.UpdatePointCounters(true);
            GameManager.gameManagerInstance.AnsweredCorrect();
        }
    }

    public void SetAnswerButtonInfo(Scale scale)
    {
        myScaleObject = scale;
        myName = scale.ScaleName;
        myText.text = scale.ScaleName;
        ButtonScaleState = scale.MyScaleEnum;
    }
}
