using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Leap;
using Leap.Unity;

public class Bird : MonoBehaviour 
{
    Controller controller;
    Hand hand;
    Frame frame;
    Arm arm;


    
    //public float upForce = 50f;					//Силата на репел(ако се ползва клавиатура или мишка)
	private bool isDead = false;			//Булеан, първична стойност false, задава дали птицата е ударела нещо или не.
    

    private Animator anim;					//Реферация към аниматор компонента на птицата.
	private Rigidbody2D rb2d;               //Реферация към Rigidbody2D компонента на птицата.


    float HandWristRot;
    //float HandPalmPitch;
    float HandPalmYaw;
    float HandPalmRoll;
    





    void Start()
	{
		//"Взема" реферацията към аниматора.
		anim = GetComponent<Animator>();
        //"Взима" реферацията към Rigidbody2D.
        rb2d = GetComponent<Rigidbody2D>();

         
    }

   
	void Update()
	{
        controller = new Controller(); //Създава нов контролер за ръцете.
        Frame frame = controller.Frame();  
        List<Hand> hands = frame.Hands;   
        
        if (frame.Hands.Count > 0) //Пита дали има ръце във фрейма
		{
            Hand firstHand = hands[0]; 
        }

        //HandPalmPitch = hands [0].PalmNormal.Pitch; 
        HandPalmYaw = hands[0].PalmNormal.Yaw; 
        HandPalmRoll = hands[0].PalmNormal.Roll;
        

        HandWristRot = hands[0].WristPosition.Pitch;

        //Debug.Log("Pitch: " + HandPalmPitch);
        Debug.Log("Yaw: " + HandPalmYaw);
        Debug.Log("Roll: " + HandPalmRoll);

        if (isDead == false && HandPalmYaw > -2f && HandPalmYaw < 3.5f)
        {
            anim.SetTrigger("Flap");
            rb2d.velocity = Vector3.zero;
            rb2d.AddForce(new Vector3(0, 50, 0));
           //rb2d.transform.Translate(new Vector3(0, 1, 0 ));
        }
        else if(isDead == false && HandPalmYaw < -2.2f)
        {
            anim.SetTrigger("Flap");
            rb2d.velocity = Vector3.zero;
            rb2d.AddForce(new Vector3(0, -50, 0));
            //rb2d.transform.Translate(new Vector3(0, -1, 0));
        }




    }

	void OnCollisionEnter2D(Collision2D other)
	{
		// Прави скоросота на птицата 0
		rb2d.velocity = Vector2.zero;
		//...Ако колайдера на птицата се удари в колайдера на земята или препятствията = мъртва = GameOver.
		isDead = true;
		//Комуникатор с аниматора
		anim.SetTrigger ("Die");
		//...Комуникатор със GameControler класа и задава инстанция GameOver.
		GameControl.instance.BirdDied ();
	}
}
