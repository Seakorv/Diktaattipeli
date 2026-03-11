using UnityEngine;

public class ScaleNotes : MonoBehaviour
{
    /// <summary>
    /// The scale's length. It's constant right now when there is only basic eight note scales in the game.
    /// </summary>
    public const int ScaleLength = 8;
    [SerializeField] private ScaleNote[] scalenotes = new ScaleNote[ScaleLength];

    public static ScaleNotes scaleNotesInstance;

    void Awake()
    {
        scaleNotesInstance = this;
    }

    public int GetScaleNotesLength()
    {
        return ScaleLength;
    }
}
