using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Parameters
{
    

    /// <summary>
    /// Background scrolling speed value assigned via the UI slider.
    /// </summary>    
    public float ScrollSpeeds
    {
        get
        {
            float ScSpeedTempValue = -1.5f;        
            GameControl.Instance.SetSpeed(ScSpeedTempValue);  //Uses GameControl SetSpeed method on ScrollSpeed.
            return ScSpeedTempValue;                          
        } 
    }
   


    /// <summary>
    /// Premade column array size.
    /// </summary>
    public int ColumnPoolSize = 5;

    /// <summary>
    /// Frequency of column spawn.
    /// </summary>
    public float SpawnRate = 3f;

    /// <summary>
    /// Minimum column Y position.
    /// </summary>
    public float ColumnMinY = -1f;

    /// <summary>
    /// Maximum column Y position
    /// </summary>
    public float ColumnMaxY = 3.5f;

    /// <summary>
    /// Current column index.
    /// </summary>
    public int CurrentColumn = 0;

    /// <summary>
    /// Column X spawn position.
    /// </summary>
    public float SpawnXPosition = 10f;

    /// <summary>
    /// The time that passed since tha last collumn spawn.
    /// </summary>
    public float TimeSinceLastSpawned;


    /// <summary>
    /// Innitializing a float as a starting point for the time when the hand is in upward possition. 
    /// </summary>
    public float TimesUp;

    /// <summary>
    /// Innitializing a float as a starting point for the time when the hand is in downward possition.
    /// </summary>
    public float TimesDown;
    


}
