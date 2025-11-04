using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    [SerializeField] private AnswerButton[] answerButtons = new AnswerButton[4];

    void Start()
    {
        answerButtons[0].IsCorrect = true;
    }
    
}
