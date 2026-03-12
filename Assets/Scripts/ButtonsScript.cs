using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    public const int ButtonsLength = 4;
    [SerializeField] private AnswerButton[] answerButtons = new AnswerButton[ButtonsLength];
    [SerializeField] private KeynoteButtonScript keynoteButton;
    public static ButtonsScript buttonsInstance;

    void Awake()
    {
        buttonsInstance = this;
    }

    void Start()
    {
        //answerButtons[0].IsCorrect = true;
    }

    public int GetButtonsLength()
    {
        return ButtonsLength;
    }

    public void SetButtonInfo(int buttonIndex, Scale scale, bool correct)
    {
        answerButtons[buttonIndex].SetAnswerButtonInfo(scale);
        answerButtons[buttonIndex].IsCorrect = correct;
    }
}
