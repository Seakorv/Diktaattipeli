using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtonScript : MonoBehaviour
{
    [SerializeField] private int myNumber;
    [SerializeField] private string myName; //Väliaikainen
    [SerializeField] private Button myButton;
    [SerializeField] private TextMeshProUGUI myText;

    //[SerializeField] private  myScaleName;
    public bool IsCorrect { get; set; } = false;

    void Start()
    {
        SetButtonName();
        SetButtonText();
        Debug.Log(myButton.name);
        myButton.onClick.AddListener(TaskOnClick);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnClick()
    {
        Debug.Log("Painoin nappulaa");
    }

    public void SetButtonName()
    {
        myButton.name = myName;
    }

    public void SetButtonText()
    {
        myText.text = $"Asteikko {myName}";
    }


}
