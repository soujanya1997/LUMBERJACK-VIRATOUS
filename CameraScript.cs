using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private Transform PlayerPosition;
	private Vector3 offset ;
	private Vector3 MoveVector;
	public AudioSource audio ;
	private float transition = 0.0f ;
	private float animationDuration = 2.0f ;
	private Vector3 animationOffset ; 
	// Use this for initialization
	void Start () 
	{
		int music = PlayerPrefs.GetInt ("music");

		Debug.Log (music);

		if (music == 1) {

			audio.Play ();
		} 
		if (music == 0)
			audio.Stop ();
			
		PlayerPosition = GameObject.FindGameObjectWithTag ("Player").transform;
		offset = transform.position - PlayerPosition.position ;
		animationOffset = offset;
	}
	
	// Update is called once per frame
	void Update () 
	{
		MoveVector = PlayerPosition.position + offset;

		MoveVector.y = Mathf.Clamp (MoveVector.y, -15, 20);


		if (transition > 1.0f) 
		{
			MoveVector.x = 0;
			transform.position = MoveVector;
			//transform.LookAt(Vector3.down);
		} 
		else 
		{
			transform.position = Vector3.Slerp (MoveVector + animationOffset, MoveVector, transition);
			transition += Time.deltaTime * 2 / animationDuration;
			transform.LookAt (PlayerPosition.position + Vector3.up);
		}

 	}

}
