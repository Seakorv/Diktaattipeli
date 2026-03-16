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
    
    /// <summary>
    /// Setting the highscore information for the statistics popup window
    /// </summary>
    /// <param name="scoreOne">Game mode one's highscore</param>
    /// <param name="scoreTwo">Game mode two's highscore</param>
    public void SetStatisticsScore(int scoreOne, int scoreTwo)
    {
        highScoreOne.text = scoreOne.ToString();
        highScoreTwo.text = scoreTwo.ToString();
    }

    /// <summary>
    /// Setting the most correct and most wrong answered scales information
    /// </summary>
    /// <param name="correct">Most correct answered scale</param>
    /// <param name="wrong">Most wrong answered scale</param>
    public void SetStatisticsMostCorrectWrong(string correct, string wrong)
    {
        mostCorrect.text = correct;
        mostWrong.text = wrong;
    }

    public void SetSpeedStatisticsGmOne(string fast, string slow)
    {
        fastestScaleGmOne.text = fast;
        slowestScaleGmOne.text = slow;
    }

    public void SetSpeedStatisticsGmTwo(string fast, string slow)
    {
        fastestScaleGmTwo.text = fast;
        slowestScaleGmTwo.text = slow;
    }
}
