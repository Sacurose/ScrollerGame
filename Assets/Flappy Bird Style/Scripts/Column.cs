﻿using UnityEngine;
using System.Collections;

public class Column : MonoBehaviour 
{
    /// <summary>
    /// If the bird hits the trigger collider in between the columns then tell the game control that the bird scored.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
	{
		if(other.GetComponent<Bird>() != null)
		{
			//If the bird hits the trigger collider in between the columns then
			//tell the game control that the bird scored.
			GameControl.Instance.BirdScored();
		}
	}
}
