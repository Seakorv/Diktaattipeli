using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtonScript : MonoBehaviour
{
    [SerializeField] private int myNumber;
    [SerializeField] private string myName; //Väliaikainens
    [SerializeField] private Button myButton;

    //[SerializeField] private  myScaleName;
    public bool isCorrect {get; set;} = false;
    // Update is called once per frame  
    void Update()
    {

    }
}
