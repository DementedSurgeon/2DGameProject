using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour {

	public Canvas canvas;
	public Button startButton;
	public Button helpButton;
	public Button quitButton;

	private Button backButton;
	private GameObject menu;
	private GameObject help;

	// Use this for initialization
	void Start () {
		menu = canvas.transform.Find ("Menu").gameObject;
		help = canvas.transform.Find ("Help").gameObject;
		backButton = help.transform.Find ("Back").GetComponent<Button> ();
		startButton.onClick.AddListener(delegate() {
			SceneManager.LoadScene("SD");
		});
		helpButton.onClick.AddListener (OpenHelp);
		quitButton.onClick.AddListener(Application.Quit);
		backButton.onClick.AddListener (CloseHelp);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OpenHelp()
	{
		menu.SetActive (false);
		help.SetActive (true);
	}

	void CloseHelp()
	{
		menu.SetActive (true);
		help.SetActive (false);
	}
}
