using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public string ScaleName { get; set; } = "";
    public int ID { get; set; } = 0;

    private int[] myAugments;

    public CurrentScaleState MyScaleEnum { get; set; }

    public void SetIDNameAndEnum(int id, String scaleName, CurrentScaleState scaleState)
    {
        ID = id;
        ScaleName = scaleName;
        MyScaleEnum = scaleState;
    }

    /// <summary>
    /// Set the scale's augments for second game mode. Augments like is it a b2, #4 etc. -1 is b, 1 is #.
    /// All zeros (0) will make the scale basic major (ionian). Every scale references to ionian. 
    /// For example [0 -1 -1 0 0 -1 -1 0] will be Phrygian. First and last will always be zero.
    /// Giving numbers outside of -1, 0, 1 will default to 0.
    /// </summary>
    public void SetAugments(int [] augments)
    {
        myAugments = new int[8];
        //Making the unison and octave 0. 
        augments[0] = 0;
        augments[augments.Length - 1] = 0;

        //Checking if the table elements are within range.
        for (int i = 1; i < augments.Length -1; i++)
        {
            if (-1 > augments[i] || augments[i] > 1)
            {
                augments[i] = 0;
            }
        }

        myAugments = augments;
    }

    public int[] GetAugments()
    {
        return myAugments;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
