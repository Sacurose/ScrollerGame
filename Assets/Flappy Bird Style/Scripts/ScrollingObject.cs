using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour     
{
    /// <summary>
    /// Reference to the RigidBody of the GameOngject that this script is attached to.
    /// </summary>
	private Rigidbody2D rb2d;

    /// <summary>
    /// Gets and store a reference to the Rigidbody2D attached to this GameObject and starts its movement.
    /// </summary>
    void Start () 
	{		
		rb2d = GetComponent<Rigidbody2D>();
        
        rb2d.velocity = new Vector2(GameControl.Instance.Parameters.ScrollSpeeds, 0);
    }


    /// <summary>
    /// If the game is over, stop scrolling.
    /// </summary>
    void Update()
	{		
		if(GameControl.Instance.GameOver == true)
		{
			rb2d.velocity = Vector2.zero;
		}
	}
}
