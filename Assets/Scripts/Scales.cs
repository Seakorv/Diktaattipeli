using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Scales : MonoBehaviour
{
    public const int AmountOfScales = 7;
    public List<Scale> AllScales { get; private set; }
    public List<Scale> AllScalesRandomOrder;
    public CurrentScaleState currentScale;
    public static Scales scaleInstance;
    private Scale testiScale;
    private int currentScaleIndex = 0;
    private static Random rng = new();
    private bool isRandomised = false;
    [SerializeField] private TextMeshProUGUI currentScaletext;

    public static event Action<CurrentScaleState> OnScaleStateChanged;

    void Awake()
    {
        scaleInstance = this;
        SetEveryScale();
        //Debug
        for (int i = 0; i < AllScales.Count; i++)
        {
            Debug.Log(AllScales[i].ScaleName);
        }
        RandomizeScaleList();
    }


    void Start()
    {
        //Always starting at the beginning of the list
        UpdateCurrentScale(AllScalesRandomOrder[currentScaleIndex].MyScaleEnum);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetEveryScale()
    {
        AllScales = new List<Scale>();
        for (int i = 0; i < AmountOfScales; i++)
        {
            AllScales.Add(gameObject.AddComponent<Scale>());
        }
        // Setting scales manually because every scale has different name. First are normal 'church' modes.
        AllScales[0].SetIDNameAndEnum(0, "Ionian", CurrentScaleState.Ionian);
        AllScales[1].SetIDNameAndEnum(1, "Dorian", CurrentScaleState.Dorian);
        AllScales[2].SetIDNameAndEnum(2, "Phrygian", CurrentScaleState.Phrygian);
        AllScales[3].SetIDNameAndEnum(3, "Lydian", CurrentScaleState.Lydian);
        AllScales[4].SetIDNameAndEnum(4, "Mixolydian", CurrentScaleState.Mixolydian);
        AllScales[5].SetIDNameAndEnum(5, "Aiolian", CurrentScaleState.Aeolian);
        AllScales[6].SetIDNameAndEnum(6, "Locrian", CurrentScaleState.Locrian);
        //AllScales[7].SetIDNameAndEnum(7, "Game Over", CurrentScaleState.GameOver);
    }

    /// <summary>
    /// Randomize all scale list
    /// </summary>
    public void RandomizeScaleList()
    {
        if (!isRandomised)
        {
            isRandomised = true;
            AllScalesRandomOrder = AllScales.ToList();
        }

        int count = AllScalesRandomOrder.Count;

        for (int i = 0; i < count; i++)
        {
            int r = UnityEngine.Random.Range(i, count);
            Scale tmp = AllScalesRandomOrder[i];
            AllScalesRandomOrder[i] = AllScalesRandomOrder[r];
            AllScalesRandomOrder[r] = tmp;
        }
    }


    public void UpdateCurrentScale(CurrentScaleState newScaleState)
    {
        currentScale = newScaleState;
        SetButtonScales();
        //currentScaleIndex += 1;
        if (newScaleState != CurrentScaleState.None || newScaleState != CurrentScaleState.GameOver)
        {
            currentScaletext.text = GetScaletextFromRandomList();
        }

        switch (newScaleState)
        {
            case CurrentScaleState.None:
                break;
            case CurrentScaleState.Ionian:
                    
                break;
            case CurrentScaleState.Dorian:

                break;
            case CurrentScaleState.Phrygian:

                break;
            case CurrentScaleState.Lydian:

                break;
            case CurrentScaleState.Mixolydian:

                break;
            case CurrentScaleState.Aeolian:

                break;
            case CurrentScaleState.Locrian:

                break;
            case CurrentScaleState.GameOver:
                // Pelin päättymistila
                break;
        }

        OnScaleStateChanged?.Invoke(newScaleState);
    }

    public string GetScaletextFromRandomList()
    {
        return AllScalesRandomOrder[currentScaleIndex].ScaleName;
    }

    public void SetButtonScales()
    {
        int buttonsLength = ButtonsScript.buttonsInstance.GetButtonsLength();

        int correctButton = rng.Next(0, buttonsLength);
        int randomScaleIndex = currentScaleIndex;
        int[] usedIndex = new int[buttonsLength];
        // Setting up usedindexes so they are under lowest possible rng scale index
        for (int i = 0; i < buttonsLength; i++)
        {
            usedIndex[i] = -1;
        }
        //ButtonsScript.buttonsInstance.SetButtonInfo(correctButton, AllScalesRandomOrder[currentScaleIndex].ScaleName, true);
        //ButtonsScript.buttonsInstance.SetButtonScaleState(correctButton, AllScalesRandomOrder[currentScaleIndex].MyScaleEnum);

        //For loop jossa kysytään, että onko tämä index correctButton. jos ei, valitaan random scale ja on false.
        // Ensimmäiseen näppäimeen asteikko randomilla. Talteen mikä asteikkoindeksi
        // Toiseen randomilla. Katsotaan usedIndex 0 onko sama. Jos kyllä, uusi random. Jos ei, tallennetaan usedindex 1 
        // Kolmanteen randomilla. Katsotaan usedIndex 0,1 onko sama. jne
        // Neljännessä katsotaan 0, 1, 2
        // Jokaisessa vaiheessa pitää katsoa, ettei ole sama kuin currentScaleIndex, muuten uusiksi

        // Randomisointi: Katsotaan, onko random sama kuin oikea, jos on, jatketaan looppia jotta löytyy uusi.


        for (int i = 0; i < buttonsLength; i++)
        {
            randomScaleIndex = GetRandomScaleIndex();
            if (i == correctButton)
            {
                ButtonsScript.buttonsInstance.SetButtonInfo(correctButton, AllScalesRandomOrder[currentScaleIndex].ScaleName, true);
                ButtonsScript.buttonsInstance.SetButtonScaleState(correctButton, AllScalesRandomOrder[currentScaleIndex].MyScaleEnum);
            }
            else //Aluksi voi olla samoja
            {
                for (int j = 0; j < usedIndex.Length; j++)
                {
                    if (usedIndex[j] == randomScaleIndex)
                    {
                        randomScaleIndex = GetRandomScaleIndex(randomScaleIndex);
                    }
                }
                ButtonsScript.buttonsInstance.SetButtonInfo(i, AllScalesRandomOrder[randomScaleIndex].ScaleName, false);
                ButtonsScript.buttonsInstance.SetButtonScaleState(i, AllScalesRandomOrder[randomScaleIndex].MyScaleEnum);
                usedIndex[i] = randomScaleIndex;
            }
        }
    }

    /// <summary>
    /// Randomizing scale index. Cannot be the current correct scale
    /// </summary>
    /// <returns>Randomised wrong scale index</returns>
    public int GetRandomScaleIndex(int oldRandom = -1)
    {
        int randomScaleIndex = currentScaleIndex;
        if (oldRandom == -1) //If we are not re-randomizing
        {
            while (randomScaleIndex == currentScaleIndex)
            {
                randomScaleIndex = rng.Next(0, AmountOfScales);
            }
        }
        else // If we are re-randomizing. oldRandom will be given in a parameter then.
        {
            while (randomScaleIndex == oldRandom || randomScaleIndex == currentScaleIndex)
            {
                randomScaleIndex = rng.Next(0, AmountOfScales);
            }
        }

        return randomScaleIndex;
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
