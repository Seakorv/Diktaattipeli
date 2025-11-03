using UnityEngine;

public class Scales : MonoBehaviour
{
    private Scale[] allScales = new Scale[0];
    public CurrentScaleState currentScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public enum CurrentScaleState
{
    None,
    Ionian,
    Dorian,
    Phrygian,
    Lydian,
    Mixolydian,
    Aeolian,
    Locrian,
}
