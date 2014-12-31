using UnityEngine;
using System.Collections;

public class BritishDropOut : MonoBehaviour {

//	void Movement();
	public float Movementspeed = 4;
	//public float Movement_x;

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Movement ();
	}

	void Movement()
	{

		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Translate(Vector2.right * Movementspeed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0);
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Translate(Vector2.right * Movementspeed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,180);
		}



	}



}
