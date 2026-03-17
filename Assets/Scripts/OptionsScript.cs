using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private Slider masterVolumeSlider;

    void Start()
    {
        closeButton.onClick.AddListener(OnClose);
    }

    public void OnClose()
    {
        this.gameObject.SetActive(false);
    }
}
