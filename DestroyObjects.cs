using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class DestroyObjects : MonoBehaviour {

	public bool attack ;
	public bool win = false ;
	public AudioSource ac;
	public float lastUpdate ;
	public Text FinalNameText;
	public Text FinalScoreText;
	public string Name;
	public int Highscore;
	public AudioSource audioS;
	public AudioClip audioC1;
	public AudioClip audioC2;
	public AudioClip audioC3;
	public AudioClip audioC4;
	public AudioClip audioC5;
	public Camera mainCam;
	public bool death;
	public Image damageImage;
	public Color flashColor;
	public float flashSpeed = 5f;
	public int score = 0;
	public int health = 100;
	public Text scoreText;
	public Text healthText;
	private int difficultyLevel = 1;
	private int maxDifficultyLevel = 10;
	private int scoreToNextLevel = 10;
	public GameObject deathMenu;
	public GameObject pauseMenu;
	public AudioSource audi;
	// Use this for initialization
	void Start () 
	{
		audi = GetComponent<AudioSource> ();
		lastUpdate = Time.time;
		score = 0;
		scoreText.text = score.ToString ();
		healthText.text = health.ToString ();
		Name = PlayerPrefs.GetString("PresentName");
		deathMenu.SetActive(false) ;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Obstacle") && !death) {
			health -= 20;
			Destroy (other.gameObject);
			damageImage.color = flashColor;

			audioS = mainCam.GetComponent<AudioSource> () ;
			audioS.clip = audioC1;
			audioS.Play();

			if (health - 20 < 0) {
				health = 0;
				audioS = mainCam.GetComponent<AudioSource> () ;
				audioS.clip = audioC5;
				audi.Pause ();
				audioS.Play();
				death = true;
			}
		} else
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed *100 * Time.deltaTime);

		if (other.CompareTag ("Enemy") && !death) 
		{
			health -= 25;
			Destroy (other.gameObject);
			audioS = mainCam.GetComponent<AudioSource> () ;
			audioS.clip = audioC2;
			audioS.Play();
			if (health - 25 < 0) {
				health = 0;
				audioS = mainCam.GetComponent<AudioSource> () ;
				audioS.clip = audioC5;
				audi.Pause ();
				audioS.Play();
				death = true;
			}
		}
		if (other.CompareTag ("Crystal") && !death) 
		{
			audioS = mainCam.GetComponent<AudioSource> () ;
			audioS.clip = audioC3;
			audioS.Play();
			score += 10;
			Destroy (other.gameObject);

		}
		if (other.CompareTag ("Fruit") && !death) 
		{
			if (health + 5 >= 100)
				health = 100;
			else
				health += 5;
			Destroy (other.gameObject);
			audioS = mainCam.GetComponent<AudioSource> () ;
			audioS.clip = audioC4;
			audioS.Play();
		}
		if (other.CompareTag ("Home")) 
		{
			Win ();
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if(Time.time - lastUpdate >= 1f && !death)
		{
			score += 1 ;
			health -= 1;
			lastUpdate = Time.time;
		}

		if (score >= scoreToNextLevel)
			LevelUp ();

		healthText.text = health.ToString();
		scoreText.text = score.ToString();

		if (death) 
		{
			Death ();
		}

		if (this.transform.position.y <= -15) 
		{
			audioS = mainCam.GetComponent<AudioSource> () ;
			audioS.clip = audioC5;
			audi.Pause ();
			audioS.Play();
			death = true;
		}
	}

	public void Death()
	{
		deathMenu.SetActive(true);
		int temp = PlayerPrefs.GetInt ("Highscore");
		if (score >= temp) 
		{
			PlayerPrefs.SetInt ("Highscore", score);
			PlayerPrefs.SetString ("Name", Name);
		}
		FinalNameText.text = PlayerPrefs.GetString ("Name");
		FinalScoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
		PlayerPrefs.Save ();

	}

	public void PauseGame()
	{
		audi.Pause ();
		Time.timeScale = 0;
		pauseMenu.SetActive (true);
	}

	public void ResumeGame()
	{
		audi.UnPause ();
		pauseMenu.SetActive (false);
		Time.timeScale = 1;
	}

	public void Win()
	{
		win = true;
		score += 1000;
		audi.Pause ();
		ac.Play ();
		death = true;
	}

	void LevelUp()
	{
		if (difficultyLevel == maxDifficultyLevel)
			return;
		scoreToNextLevel *= 2;
		difficultyLevel++;

		GetComponent<PlayerControl> ().setSpeed(difficultyLevel);
	}

	public void playAgain()
	{
		Time.timeScale = 1;
		Application.LoadLevel ("RunRajaRunMenu");
	}

	public void Replay()
	{
		Time.timeScale = 1;
		Application.LoadLevel ("RunRajaRun");
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
