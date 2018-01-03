using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour {

	public float max = 1.3f ;
	public float min = -1.3f ;

	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3 (Mathf.PingPong (Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
	}
}
