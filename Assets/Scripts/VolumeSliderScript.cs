using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is basically copied from my Scaledoku project.
/// </summary>
public class VolumeSliderScript : MonoBehaviour
{
    [SerializeField] private Slider thisSlider;
    [SerializeField] private AK.Wwise.RTPC volumeRTPC;

    void Start()
    {
        thisSlider.value = volumeRTPC.GetGlobalValue();
    }

    public void SetVolume()
    {
        volumeRTPC.SetGlobalValue(thisSlider.value);
    }
}
