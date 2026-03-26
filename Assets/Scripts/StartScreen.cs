using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(OnStartClick);
    }


    public void OnStartClick()
    {
        SceneManager.LoadSceneAsync(1);
    }

}
