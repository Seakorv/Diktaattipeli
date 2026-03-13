using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScaleNote : MonoBehaviour
{
    /// <summary>
    /// This note's number on a scale. Will be 1-8 currently. 0 is none 
    /// </summary>
    [SerializeField] private int myScaleNumber;
    /// <summary>
    /// This note's augment, is it sharp, flat or normal. Sharp is 1, flat is -1, normal is 0
    /// </summary>
    public int MyAugmentNumber { get; private set; }
    [SerializeField] private Color myColor;
    [SerializeField] private Color highlightColor;

    //Buttons
    [SerializeField] private Button noteButton;
    [SerializeField] private Button sharpButton;
    [SerializeField] private Button flatButton;
    [SerializeField] private TextMeshProUGUI myText;

    [Header("Wwise SFX")]
    [SerializeField] private AK.Wwise.Event mySound;
    [SerializeField] private AK.Wwise.Event mySoundFlat;
    [SerializeField] private AK.Wwise.Event mySoundSharp;

    //[Header("SFX")]
    
    

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Start()
    {
        MyAugmentNumber = 0;
        noteButton.onClick.AddListener(OnNoteClick);
        sharpButton.onClick.AddListener(OnSharpClick);
        flatButton.onClick.AddListener(OnFlatClick);
        SetMyText();
    }

    public void OnNoteClick()
    {
        PlayMyNote();
    }

    public void SetMyAugment(int augmentNumber)
    {
        MyAugmentNumber = augmentNumber;
        SetMyAugText();
    }

    public void SetMyText()
    {
        myText.text = myScaleNumber.ToString();
    }

    public void SetMyAugText()
    {
        switch (MyAugmentNumber)
        {
            case 0:
                myText.text = myScaleNumber.ToString();
                break;
            case 1:
                myText.text = "#" + myScaleNumber.ToString();
                break;
            case -1:
                myText.text = "b" + myScaleNumber.ToString();
                break;
        }
    }

    /// <summary>
    /// Highlighting or taking the highlight off
    /// </summary>
    /// <param name="onOff">True if want to highlight, false if wanting to take it off</param>
    public void Highlight(bool onOff)
    {
        ColorBlock highlight = noteButton.colors;        

        if (onOff)
        {
            Debug.Log("Highlight");
            highlight.normalColor = highlightColor;
            noteButton.colors = highlight;
        }
        if (!onOff)
        {
            Debug.Log("Highligt off");
            highlight.normalColor = myColor;
            noteButton.colors = highlight;
        }
    }

    public void OnFlatClick()
    { 
        if (MyAugmentNumber == -1)
        {
            PlayMyNote();
            return;
        }
        else
        {
            MyAugmentNumber--;
            Debug.Log("Flatten " + myScaleNumber + " to " + MyAugmentNumber);
        }
        PlayMyNote();
        SetMyAugText();
    }

    public void OnSharpClick()
    {
        if (MyAugmentNumber == 1)
        {
            PlayMyNote();
            return;
        }
        else
        {
            MyAugmentNumber++;
            Debug.Log("Sharpen " + myScaleNumber + " to " + MyAugmentNumber);
        }
        PlayMyNote();
        SetMyAugText();
    }

    public void PlayMyNote()
    {
        Debug.Log("Nuotti soi");
        switch (MyAugmentNumber)
        {
            case 0: 
                mySound.Post(gameObject);
                break;
            case 1:
                mySoundSharp.Post(gameObject);
                break;
            case -1:
                mySoundFlat.Post(gameObject);
                break;
        }
    }
}
