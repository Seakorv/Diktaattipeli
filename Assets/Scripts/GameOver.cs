using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button toMainMenuButton;

    void Awake()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        toMainMenuButton.onClick.AddListener(OnMainMenuClick);
    }

    private void OnStartButtonClick()
    {
        GameModeOne.gameModeOneInstance.StartGame();
        this.gameObject.SetActive(false);  
    }

    private void OnMainMenuClick()
    {
        Debug.Log("Pitäisi sulkea peli ja mennä main menuun");
    }

    public void SetPoints(int points)
    {
        pointsText.text = $"Points: {points}";
    }
}
