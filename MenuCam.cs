using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.SceneManagement ;

public class MenuCam : MonoBehaviour {

	public float speed = 0f ;
	private Vector3 Vector ;
	public int score;
	public GameObject inputField ;
	public Text inputFieldText;
	public CharacterController controller;
	public Text highscore ;
	public int flag1 = 0;
	public GameObject musicMenu;
	public Toggle musicToggle ;
	public AudioSource gameSound ;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		inputField.SetActive (false);
		score = PlayerPrefs.GetInt ("Highscore");
		highscore.text = score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector = Vector3.zero;
		if(flag1 == 0)
			Vector.z = 3f  ;
		Vector.y = -9.8f;

		if (this.transform.position.z == 100) {
			Vector.z = 0;
			flag1 = 1;
		}

		//controller.Move (Vector * Time.deltaTime);
	}

	public void TakeName()
	{
		inputField.SetActive(true);
	}

	public string Name = "" ;

	public void MenuActions(string scene)
	{
		Name = inputFieldText.text;
		if (!(Name.Equals (""))) {
			PlayerPrefs.SetString ("PresentName", Name);
			//Application.LoadLevel (scene);
			SceneManager.LoadScene (scene);
		}
	}

	public void musicSettings()
	{
		musicMenu.SetActive(true);
	}

	public void musicOk()
	{
		if (musicToggle.isOn) 
		{
			PlayerPrefs.SetInt ("music", 1);
		}
		else
			PlayerPrefs.SetInt ("music", 0);

		musicMenu.SetActive(false) ;
			
		int music = PlayerPrefs.GetInt ("music");

		if (music == 0)
			gameSound.Stop();
		else
			gameSound.Play();
	}

	public void exitNow()
	{
		Application.Quit ();
	}

}
