using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class gameCam : MonoBehaviour {

	public Text name;
	public Text score;
	// Use this for initialization
	void Start () {
		name.text = PlayerPrefs.GetString ("Name");
		score.text = PlayerPrefs.GetInt("Highscore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
