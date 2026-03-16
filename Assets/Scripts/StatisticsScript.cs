using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatisticsScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreOne;
    [SerializeField] private TextMeshProUGUI highScoreTwo;
    [SerializeField] private TextMeshProUGUI mostCorrect;
    [SerializeField] private TextMeshProUGUI mostWrong;
    [SerializeField] private TextMeshProUGUI fastestScaleGmOne;
    [SerializeField] private TextMeshProUGUI fastestScaleGmTwo;
    [SerializeField] private TextMeshProUGUI slowestScaleGmOne;
    [SerializeField] private TextMeshProUGUI slowestScaleGmTwo;
    [SerializeField] private Button closeButton;

    void Start()
    {
        closeButton.onClick.AddListener(CloseStatistics);
    }

    public void CloseStatistics()
    {
        this.gameObject.SetActive(false);
    }
    
    public void SetStatistics(int highscoreOne, int highscoreTwo, string mostCorrect, string mostWrong, string fastOne, string fastTwo, string slowOne, string slowTwo)
    {
        
    }
}
