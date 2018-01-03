using System.Collections;
using UnityEngine;
using UnityEngine.UI ;


public class CameraFollow : MonoBehaviour {

	private Transform PlayerPosition;
	private Vector3 offset ;
	private Vector3 MoveVector;
	public GameObject menuCanvas;
	public AudioSource aud;
	private float transition = 0.0f ;
	private float animationDuration = 6.0f ;
	private Vector3 animationOffset ; 
	public Toggle musicToggle;
	// Use this for initialization
	void Start () {

		aud = GetComponent<AudioSource> ();

		int music = PlayerPrefs.GetInt ("music");

		if (music == 0) {
			musicToggle.isOn = false;
			aud.Stop ();
		} else
			aud.Play ();

		

		menuCanvas.SetActive (false);
		PlayerPosition = GameObject.FindGameObjectWithTag ("Player").transform;
		offset = transform.position - PlayerPosition.position ;
		animationOffset = offset;
	}
	
	// Update is called once per frame
	void Update () {
		MoveVector = PlayerPosition.position + offset;

		//MoveVector.y = Mathf.Clamp (MoveVector.y, -15, 20);


		if (transition > 6.0f) 
		{
			//MoveVector.x = 0;
			transform.position = MoveVector;
			//transform.LookAt(Vector3.down);
		} 
		else 
		{
			transform.position = Vector3.Slerp (MoveVector + animationOffset*3, MoveVector, transition);
			transition += Time.deltaTime * 3 / animationDuration;
			transform.LookAt (PlayerPosition.position + Vector3.up);
		}

		if (Time.time > 4f) 
		{
			menuCanvas.SetActive (true);
		}
	}
}
