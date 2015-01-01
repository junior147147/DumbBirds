using UnityEngine;
using System.Collections;

public class DumbBird : MonoBehaviour {


	public Transform sightStart, sightEnd;
	public bool spotted = false;
	public GameObject markTop;
	public GameObject markBot;
	public bool facingLeft = true;


	void Start () 
	{
		InvokeRepeating ("Patrol", 0f, Random.Range(2f,6f));
	}


	// Update is called once per frame
	void Update () {
		RayCasting ();
		Behavior ();
	}


	void RayCasting()
	{
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.black);
		spotted = Physics2D.Linecast (sightStart.position, sightEnd.position , 1 << LayerMask.NameToLayer("BritishDropOut"));

	}

	void Behavior ()
	{
		if (spotted) 
		{
			markTop.SetActive(true);
			markBot.SetActive(true);
		}
		else
		{
			markTop.SetActive(false);
			markBot.SetActive(false);
		}
	}

	void Patrol ()
	{
		facingLeft = !facingLeft;
		//if true, set it to false, vice versa.
		if (facingLeft)
		{
			transform.eulerAngles= new Vector2(0,0);
		}
		else
		{
			transform.eulerAngles= new Vector2(0,180);
		}
	}


}
