using UnityEngine;
using System.Collections;

public class BritishDropOut : MonoBehaviour {

//	void Movement();
	public float Movementspeed = 4;
	public float Jumpspeed = 300f;
	public Transform grounededEnd , lineStart, lineEnd;
	public bool grounded = false;
	public bool dumbBird = false;
	public bool interact = false;
	RaycastHit2D whatIHit;

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Raycasting ();
		Movement ();
		Jump ();
		Attack ();
	}

	void Raycasting ()  
	{
		Debug.DrawLine (lineStart.position, lineEnd.position, Color.black);
		Debug.DrawLine (this.transform.position, grounededEnd.position, Color.black);

		grounded = Physics2D.Linecast (this.transform.position, grounededEnd.position, 1 << LayerMask.NameToLayer ("Ground"));



		if(Physics2D.Linecast(lineStart.position, lineEnd.position, 1<<LayerMask.NameToLayer("DumbBird")))
		  {
			whatIHit = Physics2D.Linecast(lineStart.position, lineEnd.position, 1<<LayerMask.NameToLayer("DumbBird"));
			interact =  true;
		  }
		else
		{
			interact = false;
		}
	}




	void Movement()
	{

		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.Translate(Vector2.right * Movementspeed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			transform.Translate(Vector2.right * Movementspeed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,180);
		}

	}

	void Jump ()
	{
		
		if (Input.GetKeyDown (KeyCode.Space) && grounded == true)
		{
			rigidbody2D.AddForce(Vector2.up * Jumpspeed);
		}
	
	}

	void Attack ()
	{
		if(Input.GetKeyDown (KeyCode.A) && interact == true)
		{
			Destroy(whatIHit.collider.gameObject);
		}
	}

}
