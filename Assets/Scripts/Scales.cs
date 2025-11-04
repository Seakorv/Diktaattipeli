using System;
using UnityEngine;

public class Scales : MonoBehaviour
{
    // Have to hard code numbers if i want to use tables
    public const int AmountOfScales = 7;
    private Scale[] allScales;
    public CurrentScaleState currentScale;
    public static Scales scaleInstance;
    private Scale testiScale;

    public static event Action<CurrentScaleState> OnScaleStateChanged;

    void Awake()
    {
        scaleInstance = this;
        allScales = new Scale[AmountOfScales];
        for (int i = 0; i < AmountOfScales; i++)
        {
            allScales[i] = gameObject.AddComponent<Scale>();
        }
        // Setting scales manually because every scale has different name. First are normal 'church' modes.
        allScales[0].SetIDandName(0, "Ionian");
        allScales[1].SetIDandName(1, "Dorian");
        allScales[2].SetIDandName(2, "Phrygian");
        allScales[3].SetIDandName(3, "Lydian");
        allScales[4].SetIDandName(4, "Mixolydian");
        allScales[5].SetIDandName(5, "Aiolian");
        allScales[6].SetIDandName(6, "Locrian");

        for (int i = 0; i < allScales.Length; i++)
        {
            Debug.Log(allScales[i].ScaleName);
        }
        //testiScale = gameObject.AddComponent<Scale>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //testiScale.name = "Olen testi";
        //Debug.Log(testiScale.name);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateCurrentScale(CurrentScaleState newScaleState)
    {
        currentScale = newScaleState;

        switch (newScaleState)
        {
            case CurrentScaleState.None:
                break;
            case CurrentScaleState.Ionian:
                // Näihin musat vaihtumaan, valitaan jooninen biisi jne.
                break;
            case CurrentScaleState.Dorian:
                //
                break;
            case CurrentScaleState.Phrygian:
                //
                break;
            case CurrentScaleState.Lydian:
                //
                break;
            case CurrentScaleState.Mixolydian:
                //
                break;
            case CurrentScaleState.Aeolian:
                //
                break;
            case CurrentScaleState.Locrian:
                //
                break;
            case CurrentScaleState.GameOver:
                // Pelin päättymistila
                break;
        }

        OnScaleStateChanged?.Invoke(newScaleState);
    }
}

public enum CurrentScaleState
{
    None,
    Ionian,
    Dorian,
    Phrygian,
    Lydian,
    Mixolydian,
    Aeolian,
    Locrian,
    GameOver,
}
