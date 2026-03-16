using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatisticsScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScore;
    [SerializeField] private TextMeshProUGUI mostCorrect;
    [SerializeField] private TextMeshProUGUI mostWrong;
    [SerializeField] private TextMeshProUGUI fastestScale;
    [SerializeField] private TextMeshProUGUI slowestScale;
    [SerializeField] private Button closeButton;

    void Start()
    {
        closeButton.onClick.AddListener(CloseStatistics);
    }

    public void CloseStatistics()
    {
        this.gameObject.SetActive(false);
    }
}
