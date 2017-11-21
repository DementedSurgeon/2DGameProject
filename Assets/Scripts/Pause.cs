using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public Canvas canvas;
	public GameObject player;
	private Look playerLook;
	private Look playerLook2;
	private Arsenal playerArsenal;
	private Movement playerMovement;
	private DudeAnim playerAnim;
	private Button resume;
	private Button mainMenu;
	private bool paused = false;

	// Use this for initialization
	void Start () {
		playerLook = player.transform.GetChild (0).GetComponent<Look> ();
		playerLook2 = player.transform.GetChild (1).GetComponent<Look> ();
		playerArsenal = player.GetComponentInChildren<Arsenal> ();
		playerMovement = player.GetComponent<Movement> ();
		playerAnim = player.GetComponent<DudeAnim> ();
		resume = canvas.transform.Find ("Resume").GetComponent<Button>();
		mainMenu = canvas.transform.Find ("MainMenu").GetComponent<Button>();
		resume.onClick.AddListener (PauseUnpause);
		mainMenu.onClick.AddListener (delegate() {
			PauseUnpause();
			SceneManager.LoadScene ("TitleScreen");
		}
			);

		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			PauseUnpause ();
		}
	}

	void PauseUnpause()
	{
		if (paused == false) {
			Time.timeScale = 0;
			playerArsenal.enabled = false;
			playerLook.enabled = false;
			playerLook2.enabled = false;
			playerAnim.enabled = false;
			playerMovement.enabled = false;
			resume.gameObject.SetActive (true);
			mainMenu.gameObject.SetActive (true);
			paused = true;
		} else {
			Time.timeScale = 1;
			playerArsenal.enabled = true;
			playerLook.enabled = true;
			playerLook2.enabled = true;
			playerAnim.enabled = true;
			playerMovement.enabled = true;
			resume.gameObject.SetActive (false);
			mainMenu.gameObject.SetActive (false);
			paused = false;
		}
	}
}
