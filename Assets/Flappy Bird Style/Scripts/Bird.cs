using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Leap;
using Leap.Unity;

public class Bird : MonoBehaviour 
{
    Controller controller;  
    
    /// <summary>
    /// Boolean that indicates if the bird hit a collider and thus is "dead".
    /// </summary>
	private bool isDead = false;

    /// <summary>
    /// Reference to the animator that controls the bird's animations sequences.
    /// </summary>
    private Animator anim;	
    
    /// <summary>
    /// Reference to the rigidbody of the game object that this script is attached to.
    /// </summary>
	public Rigidbody2D rb2d;

    /// <summary>
    /// The value of the Yaw of the hand.
    /// </summary>
    private float HandPalmYaw;

    //float HandWristRot;                   //Test variables that are not needed for the time being
    //float HandPalmPitch;
    //float HandPalmRoll;

    private float timesUp = 0f;
    private float timesDown = 0f;
    //bool whileUp;

   


    /// <summary>
    /// Assigns the RigidBody and Aniamtor components to their referenced values.
    /// </summary>
    void Start()
	{		
		anim = GetComponent<Animator>();
        
        rb2d = GetComponent<Rigidbody2D>();        
    }

   
    /// <summary>
    /// Update method that controls the bird with the Leap motion hand yaw data input.
    /// </summary>
	void Update()
	{
        controller = new Controller();              //Makes new controller.
        Frame frame = controller.Frame();           
        List<Hand> hands = frame.Hands;   
        
        
        if (frame.Hands.Count > 0) //Asks if there is a hand in the frame, if yes then it assign in as a new hand.
		{
            Hand firstHand = hands[0]; 
        }

        //HandPalmPitch = hands [0].PalmNormal.Pitch; 
        HandPalmYaw = hands[0].PalmNormal.Yaw;                  //Assigns the Yaw value of the hand to be the new hand's yaw value.
        //HandPalmRoll = hands[0].PalmNormal.Roll;
        

        //HandWristRot = hands[0].WristPosition.Pitch;

        //Debug.Log("Pitch: " + HandPalmPitch);
        //Debug.Log("Yaw: " + HandPalmYaw);
        //Debug.Log("Roll: " + HandPalmRoll);

        
        if (isDead == false && HandPalmYaw > -2f && HandPalmYaw < 3.5f)
        {
            
            timesUp = timesUp + Time.deltaTime;
            Debug.Log("Up: " + timesUp);
           
            anim.SetTrigger("Flap");
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, 50));
            //rb2d.transform.Translate(new Vector3(0, 1, 0 ));
        }
        else if (isDead == false && HandPalmYaw < -2.2f)
        {
           
            timesDown = timesDown + Time.deltaTime;
            Debug.Log("Down: " + timesDown);
            

            anim.SetTrigger("Flap");
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, -50));
            //rb2d.transform.Translate(new Vector3(0, -1, 0));
        }
       




    }

    /// <summary>
    /// IF the bird's collider hits an obstacle's collider, it sets that the bird is dead, makes it velocidy 0, trigger the death animation and tells the Gamecontroller
    /// to set instance to GameOver.
    /// </summary>
    /// <param name="other"></param>
	void OnCollisionEnter2D(Collision2D other)
    {		
		rb2d.velocity = Vector2.zero;
		
		isDead = true;
		
		anim.SetTrigger ("Die");
		
		GameControl.Instance.BirdDied ();
	}
}
