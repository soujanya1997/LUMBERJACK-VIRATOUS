using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Islandmovement : MonoBehaviour {

	public float max = 12f ;
	public float min = -12f ;

	// Update is called once per frame
	void Update () 
	{
		
		//transform.position = new Vector3 (transform.position.x , Mathf.PingPong (Time.time * 1.8f, max - min) - 2f , transform.position.z);
	}
}
