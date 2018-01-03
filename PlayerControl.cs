using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour 
{
	private CharacterController controller;
	public GameObject tileScript;
	TileMangerScript tile_mngr_scrpt ;
	DestroyObjects dest_obj_scrpt ;
	private Vector3 moveVector ;
	private float speed = 5.8f ;
	private float verticalVelocity = 0.0f;
	private float gravity = 9.8f ;
	private float animationDuration = 2.0f ;
	public int NextLevelRequirement = 10 ;
	//private AudioSource footsteps;
	// Use this for initialization
	void Start () 
	{
		controller = GetComponent<CharacterController>();
		//footsteps = GetComponent<AudioSource> ();

		tile_mngr_scrpt = tileScript.GetComponent<TileMangerScript> ();
		dest_obj_scrpt = this.GetComponent<DestroyObjects> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		moveVector = Vector3.zero;

			verticalVelocity -= gravity * Time.deltaTime ;

		//x
		moveVector.x = Input.GetAxisRaw ("Horizontal");
		if (Input.GetMouseButton (0)) 
		{
			if (Input.mousePosition.x > Screen.width / 2)
				moveVector.x = Time.deltaTime * 100;
			else
				moveVector.x = -Time.deltaTime * 100;
		}

		moveVector.z = speed ;

		moveVector.y = verticalVelocity;

		controller.Move (moveVector * Time.deltaTime);

		//speed += 0.005f;

		if (this.transform.position.y <= -15) 
		{
			speed = 0.0f;
			verticalVelocity = 0.0f;
			transform.Rotate (new Vector3(0,100*Time.deltaTime,0));
		}

		if(dest_obj_scrpt.death)
		{
			speed = 0.0f;
			verticalVelocity = 0.0f;
			transform.Rotate (new Vector3(0,100*Time.deltaTime,0));
		}	
	}

	public void setSpeed(float modifier)
	{
		speed = 5f + modifier; 
	}
}
