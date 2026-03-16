using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Serialization;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    //Game mode things
    [SerializeField] private int myGameModeNumber;

    /// <summary>
    /// Game mode two needs only one set up because buttons will not change their information 
    /// between answers.
    /// </summary>

    // Scale things
    public const int AmountOfScales = 7;
    /// <summary>
    /// Defines how many correct answers it will take to change the genre. 
    /// If this number is 10, it will change the genre after 10 points.
    /// </summary>
    public const int GenreChangeChecker = 10;
    public List<Scale> AllScales { get; private set; }
    public List<Scale> AllScalesRandomOrder { get; private set; }
    public CurrentScaleState currentScale;
    public CurrentGenreState currentGenreState;

    [Header("Tempo things")]
    private float currentTempo = 0f;
    [SerializeField] private float synthFunkTempo = 109f;
    [SerializeField] private float metalTempo = 90f;
    [SerializeField] private float pianoTempo = 0f;
    //note tempos are propably just needed in ScaleNotes script 
    private float quarterNote;
    private float eightNote;

    //Scale object
    public Scale CurrentScaleObject;
    private int currentScaleIndex = 0;

    // Script's instance
    public static GameManager gameManagerInstance;
    public static event Action<CurrentScaleState> OnScaleStateChanged;
    
    // Timer things
    [Header("Timer things")]
    [SerializeField] private UnityEngine.UI.Slider timerBar;
    [SerializeField] private float timerDecreaseSpeed = 1.0f;
    [SerializeField] private float wrongAnswerTimerDecrease = 50.0f;
    [SerializeField] private float correctAnswerTimerIncrease = 100.0f;
    private const float MAX_TIMER = 1000.0f;
    private bool isGameOver = false; // idk maybe it fits here
    
    // Points counter things
    [Header("Point Counter Texts")]
    [SerializeField] private TextMeshProUGUI correctCounterText;
    [SerializeField] private TextMeshProUGUI wrongCounterText;
    public int WrongCounter { get; private set; } = 0;
    public int CorrectCounter { get; private set; } = 0;

    // Rng
    private static Random rng = new();
    private bool isRandomised = false;

    // Pop Ups
    [Header("Pop up window gameobjects")]
    [SerializeField] private GameObject startGamePopUp;
    [SerializeField] private GameObject gameOverPopUp;

    // Wwise
    [Header("Wwise things")]
    // States, chances the genres of music
    public AK.Wwise.State mainMenuMusic;
    public AK.Wwise.State synthFunkState;
    public AK.Wwise.State metalState;
    
    // Switches, changes the background songs of each scale
    public AK.Wwise.Switch ionianSwitch;
    public AK.Wwise.Switch lydianSwitch;
    public AK.Wwise.Switch mixolydianSwitch;
    public AK.Wwise.Switch dorianSwitch;
    public AK.Wwise.Switch aeolianSwitch; 
    public AK.Wwise.Switch phrygianSwitch;
    public AK.Wwise.Switch locrianSwitch;
    public AK.Wwise.Switch gameOverSwitch;

    //SFX
    [SerializeField] private AK.Wwise.Event succesSFX;
    [SerializeField] private AK.Wwise.Event errorSFX;


    // Things for testing
    [Header("Things for testing")]
    [SerializeField] private TextMeshProUGUI kierroslaskuri;
    [SerializeField] private TextMeshProUGUI currentScaletext;
    private int kierrokset = -1;
    private string kierrosText = "";

    // Data saving things
    private float timeForAnswer = 0f;
    private bool correctPress = false;



    void Awake()
    {
        //Setting tempo

        gameManagerInstance = this;
        SetEveryScale();
        CurrentScaleObject = gameObject.AddComponent<Scale>();

        timerBar.maxValue = MAX_TIMER;
        timerBar.minValue = 0;

        StartGame();
    }

    void FixedUpdate()
    {
        timeForAnswer += Time.deltaTime;
        if (correctPress)
        {
            Debug.Log("Vastausaika: " + timeForAnswer);
            DataSaving.dataSavingInstance.CorrectSaving(CurrentScaleObject, timeForAnswer);
            timeForAnswer = 0f;
            correctPress = false;
        }

        if (!startGamePopUp.activeSelf)
        {
            timerBar.value -= timerDecreaseSpeed;
        }
        if (timerBar.value == 0 && !isGameOver)
        {
            DataSaving.dataSavingInstance.SaveHighScore(GetMyGameModeNumber(), CorrectCounter);
            DataSaveSystem.SaveData();
            GameOver();
        }
    }

    public void ResetAnswerTimer()
    {
        timeForAnswer = 0f;
    }

    /// <summary>
    /// Will give a random genre's enum. Will not give None
    /// </summary>
    /// <returns>A genre state enum except None</returns>
    public CurrentGenreState RandomizeGenre()
    {
        Random rnd = new Random();

        return (CurrentGenreState)rnd.Next((int)CurrentGenreState.None);
    }

    public CurrentGenreState NextGenre()
    {
        int nextGenre = (int)currentGenreState + 1;
        if (nextGenre == (int)CurrentGenreState.None)
        {
            nextGenre = 0;
        }

        return (CurrentGenreState)nextGenre;
    }

    public void SetTempo(CurrentGenreState genre)
    {
        switch (genre)
        {
            case CurrentGenreState.None:
                //Lets just set for a default 120
                quarterNote = 60f / 120f;
                eightNote = quarterNote / 2f;
                currentTempo = 120f;
                break;
            case CurrentGenreState.SynthFunk:
                quarterNote = 60f / synthFunkTempo;
                eightNote = quarterNote / 2f;
                currentTempo = synthFunkTempo;
                break;
            case CurrentGenreState.Metal:
                quarterNote = 60f / metalTempo;
                eightNote = quarterNote / 2f;
                currentTempo = metalTempo;
                break;
        }
    }

    public float GetTempo()
    {
        return currentTempo;
    }

    public int GetMyGameModeNumber()
    {
        return myGameModeNumber;
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
        AllScales[0].SetAugments(new int[8]);
        AllScales[1].SetIDNameAndEnum(1, "Dorian", CurrentScaleState.Dorian);
        AllScales[1].SetAugments(new int[] { 0, 0, -1, 0, 0, 0, -1, 0});
        AllScales[2].SetIDNameAndEnum(2, "Phrygian", CurrentScaleState.Phrygian);
        AllScales[2].SetAugments(new int[] { 0, -1, -1, 0, 0, -1, -1, 0});
        AllScales[3].SetIDNameAndEnum(3, "Lydian", CurrentScaleState.Lydian);
        AllScales[3].SetAugments(new int[] { 0, 0, 0, 1, 0, 0, 0, 0});
        AllScales[4].SetIDNameAndEnum(4, "Mixolydian", CurrentScaleState.Mixolydian);
        AllScales[4].SetAugments(new int[] { 0, 0, 0, 0, 0, 0, -1, 0});
        AllScales[5].SetIDNameAndEnum(5, "Aeolian", CurrentScaleState.Aeolian);
        AllScales[5].SetAugments(new int[] { 0, 0, -1, 0, 0, -1, -1, 0});
        AllScales[6].SetIDNameAndEnum(6, "Locrian", CurrentScaleState.Locrian);
        AllScales[6].SetAugments(new int[] { 0, -1, -1, 0, -1, -1, -1, 0});
        //AllScales[7].SetIDNameAndEnum(7, "Game Over", CurrentScaleState.GameOver);
    }

    public void SetCurrentScaleObject()
    {
        for (int i = 0; i < AllScales.Count; i++)
        {
            if (currentScale == AllScales[i].MyScaleEnum)
            {
                CurrentScaleObject = AllScales[i];
                break;
            }
        }
        Debug.Log("Current scale object: " + CurrentScaleObject.ScaleName);
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

    public void UpdateGenreState(CurrentGenreState newGenre)
    {
        currentGenreState = newGenre;
        SetTempo(currentGenreState);

        switch (newGenre)
        {
            case CurrentGenreState.None:
                mainMenuMusic.SetValue(); 
                break;
            case CurrentGenreState.SynthFunk:
                synthFunkState.SetValue();
                break;
            case CurrentGenreState.Metal:
                metalState.SetValue();
                break;
        }

        
    }

    /// <summary>
    /// Setting the state to the current scale which is playing. 
    /// The state includes the background music, setting up the button scales.
    /// </summary>
    /// <param name="newScaleState">The current scale state</param>
    public void UpdateCurrentScale(CurrentScaleState newScaleState)
    {
        currentScale = newScaleState;
        SetCurrentScaleObject();
        if (myGameModeNumber == 1) { SetGameModeOneButtonScales(); }
        //if (myGameModeNumber == 2 && !gamemodeTwoSetUp) { SetGameModeTwoButtons(); }
        
        if (newScaleState != CurrentScaleState.None || newScaleState != CurrentScaleState.GameOver)
        {
            currentScaletext.text = GetScaletextFromRandomList();
        }

        switch (newScaleState)
        {
            case CurrentScaleState.None:
                break;
            case CurrentScaleState.Ionian:
                ionianSwitch.SetValue(gameObject);
                Debug.Log("Joonisessa");
                break;
            case CurrentScaleState.Dorian:
                dorianSwitch.SetValue(gameObject);
                Debug.Log("Doorisessa");
                break;
            case CurrentScaleState.Phrygian:
                phrygianSwitch.SetValue(gameObject);
                Debug.Log("Fryygisessä");
                break;
            case CurrentScaleState.Lydian:
                lydianSwitch.SetValue(gameObject);
                Debug.Log("Lyydisessä");
                break;
            case CurrentScaleState.Mixolydian:
                mixolydianSwitch.SetValue(gameObject);
                Debug.Log("Mixolyydiessä");
                break;
            case CurrentScaleState.Aeolian:
                aeolianSwitch.SetValue(gameObject);
                Debug.Log("Aiolisessa");
                break;
            case CurrentScaleState.Locrian:
                locrianSwitch.SetValue(gameObject);
                Debug.Log("Lokrisessa");
                break;
            case CurrentScaleState.GameOver:
                gameOverSwitch.SetValue(gameObject);
                Debug.Log("Gameoverissa");
                break;
        }
        currentScaleIndex += 1;
        OnScaleStateChanged?.Invoke(newScaleState);
    }

    public string GetScaletextFromRandomList()
    {
        CheckIfCurrentScaleIsWithinRange();
        return AllScalesRandomOrder[currentScaleIndex].ScaleName;
    }

    /// <summary>
    /// Checks and sets the currentscaleindex within AmountOfScales range
    /// </summary>
    public void CheckIfCurrentScaleIsWithinRange()
    {
        if (currentScaleIndex < 0 ) { currentScaleIndex = 0; }
        if (currentScaleIndex >= AmountOfScales) { currentScaleIndex = AmountOfScales - 1; }
    }

    public void SetGameModeOneButtonScales()
    {
        CheckIfCurrentScaleIsWithinRange();
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
                ButtonsScript.buttonsInstance.SetButtonInfo(correctButton, AllScalesRandomOrder[currentScaleIndex], true);
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
                ButtonsScript.buttonsInstance.SetButtonInfo(i, AllScalesRandomOrder[randomScaleIndex], false);
                usedIndex[i] = randomScaleIndex;
            }
        }
    }

    public void SetGameModeTwoButtons()
    {
        //gamemodeTwoSetUp = true;
        CheckIfCurrentScaleIsWithinRange();
        //int scaleNotesLength = ScaleNotes.scaleNotesInstance.GetScaleNotesLength();

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


    /// <summary>
    /// Will be called in the buttonscript when the correct answer is given.
    /// Calls the scalestate to be updated to next scale and randomizing buttons again.
    /// Re-ranomizes the scales and resets current scale index if every scale has been went through
    /// </summary>
    public void AnsweredCorrect()
    {
        correctPress = true;

        // If every scale has been gone through, restart and re-randomize the list
        if (currentScaleIndex == AmountOfScales)
        {
            UpdateKierrosLaskuri(); // Testausta varten
            currentScaleIndex = 0;
            RandomizeScaleList();
        }
        
        UpdateCurrentScale(AllScalesRandomOrder[currentScaleIndex].MyScaleEnum);
    }

    /// <summary>
    /// Vain testaukseen, päivitetään kierrokset ruudulle
    /// </summary>
    private void UpdateKierrosLaskuri()
    {
        kierrokset++;
        kierrosText = $"{kierrokset}";
        kierroslaskuri.text = kierrosText;
    }

    private void ResetKierrosLaskuri()
    {
        kierrokset = 0;
        kierrosText = $"{kierrokset}";
        kierroslaskuri.text = kierrosText;
    }

    public void UpdatePointCounters(bool correct)
    {
        if (correct)
        {
            
            //succesSFX.Post(gameObject);
            timerBar.value += correctAnswerTimerIncrease;
            CorrectCounter += 1;
            ChangeGenre();
        }
        else
        {
            //
            errorSFX.Post(gameObject);
            timerBar.value -= wrongAnswerTimerDecrease;
            WrongCounter += 1;
        }
        SetCounterTexts();
    }

    /// <summary>
    /// Will change the genre after certain amount of correct answers defined by the GenreChangeChecker
    /// </summary>
    public void ChangeGenre()
    {
        if (CorrectCounter % GenreChangeChecker == 0)
        {
            UpdateGenreState(NextGenre());
        }
    }

    private void SetCounterTexts()
    {
        correctCounterText.text = $"{CorrectCounter}";
        wrongCounterText.text = $"{WrongCounter}";
    }

    private void GameOver()
    {
        isGameOver = true;
        if (currentScaleIndex >= AmountOfScales)
        {
            currentScaleIndex = AmountOfScales - 1;
        }
        //UpdateGenreState(CurrentGenreState.None);
        UpdateCurrentScale(CurrentScaleState.GameOver);
        gameOverPopUp.SetActive(true);
        gameOverPopUp.GetComponent<GameOver>().SetPoints(CorrectCounter);
    }

    public void StartGame()
    {
        RandomizeScaleList();
        SetCounterTexts();
        // Testings
        UpdateKierrosLaskuri();
        //Always starting at the beginning of the list
        
        UpdateGenreState((CurrentGenreState)0); //TODO: jotain randomisaatiota tms. kun on enemmän genrejä
        ResetCounters();
        timerBar.value = timerBar.maxValue;
        isGameOver = false;
        UpdateCurrentScale(CurrentScaleState.GameOver);
        //Debug.Log(currentScaleIndex + " Current scale index");
    }

    public void SetFirstScaleState()
    {
        CheckIfCurrentScaleIsWithinRange();
        UpdateCurrentScale(AllScalesRandomOrder[currentScaleIndex].MyScaleEnum);
    }
    
    private void ResetCounters()
    {
        CorrectCounter = 0;
        WrongCounter = 0;
        SetCounterTexts();
        ResetKierrosLaskuri();
    }

    public void FromIncorrectButton(Scale incorrect)
    {
        DataSaving.dataSavingInstance.IncorrectSaving(CurrentScaleObject, incorrect, CorrectCounter);
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

/// <summary>
/// Enums for genres. Last element is None, others should be genres
/// </summary>
public enum CurrentGenreState
{
    SynthFunk,
    Metal,
    None,
}
