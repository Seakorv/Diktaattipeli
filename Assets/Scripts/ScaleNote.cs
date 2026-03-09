using UnityEngine;
using UnityEngine.UI;

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

    //Buttons
    [SerializeField] private Button noteButton;
    [SerializeField] private Button sharpButton;
    [SerializeField] private Button flatButton;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        MyAugmentNumber = 0;
        noteButton.onClick.AddListener(OnNoteClick);
        sharpButton.onClick.AddListener(OnSharpClick);
        flatButton.onClick.AddListener(OnFlatClick);
    }

    public void OnNoteClick()
    {
        //Soita ääniefekti
    }

    public void OnFlatClick()
    {
        Debug.Log("Flatten " + myScaleNumber + " to " + MyAugmentNumber);
        if (MyAugmentNumber == -1)
        {
            //Soita ääni joka ei ole muuttunut
            return;
        }
        else
        {
            MyAugmentNumber--;
        }
        //Soita ääni
    }

    public void OnSharpClick()
    {
        Debug.Log("Sharpen " + myScaleNumber + " to " + MyAugmentNumber);
        if (MyAugmentNumber == 1)
        {
            //Soita ääni joka ei ole muuttunut
            return;
        }
        else
        {
            MyAugmentNumber++;
        }
        //Soita ääni
    }
}
