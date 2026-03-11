using UnityEngine;
using UnityEngine.UI;

public class ScaleNotes : MonoBehaviour
{
    /// <summary>
    /// The scale's length. It's constant right now when there is only basic eight note scales in the game.
    /// </summary>
    public const int ScaleLength = 8;
    [SerializeField] private ScaleNote[] scalenotes = new ScaleNote[ScaleLength];
    [SerializeField] private Button submitAnswerButton;
    [SerializeField] private Button playScaleButton;
    public static ScaleNotes scaleNotesInstance;

    void Awake()
    {
        scaleNotesInstance = this;
    }

    void Start()
    {
        submitAnswerButton.onClick.AddListener(OnSubmitClick);
        playScaleButton.onClick.AddListener(OnPlayClick);
    }

    public void SetScaleNoteAugments(int[] augments)
    {
        for (int i = 0; i < scalenotes.Length; i++)
        {
            scalenotes[i].SetMyAugment(augments[i]);
        }
    }

    public void OnSubmitClick()
    {
        int[] currentAugments = GameManager.gameManagerInstance.CurrentScaleObject.GetAugments();

        for (int i = 0; i < scalenotes.Length; i++)
        {
            if (scalenotes[i].MyAugmentNumber != currentAugments[i]) //Vertaa scaleen
            {
                
                Debug.Log("VÄÄRIN");
                GameManager.gameManagerInstance.UpdatePointCounters(false);
                //Tööt efekti
                return;
            }
        }
        Debug.Log("Oikein!");
        GameManager.gameManagerInstance.AnsweredCorrect();
        GameManager.gameManagerInstance.UpdatePointCounters(true);
    }

    public void OnPlayClick()
    {
        Debug.Log("Coroutinella soitetaan scale, Scaledokusta mallia");
        GameManager.gameManagerInstance.PrintCurrentScaleAugments();
    }
}
