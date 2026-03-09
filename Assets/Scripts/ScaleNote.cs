using UnityEngine;

public class ScaleNote : MonoBehaviour
{
    /// <summary>
    /// This note's number on a scale. Will be 1-8 currently. 0 is none 
    /// </summary>
    [SerializeField] private int myScaleNumber;
    /// <summary>
    /// This note's augment, is it sharp, flat or normal. Sharp is 1, flat is -1, normal is 0
    /// </summary>
    public int MyAugmentNumber { get; private set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
