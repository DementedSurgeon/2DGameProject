using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManagement2 : MonoBehaviour {

	public Button startButton;
	public Button quitButton;

	// Use this for initialization
	void Start () {
		startButton.onClick.AddListener(delegate() {
			SceneManager.LoadScene("TitleScreen");
		});
		quitButton.onClick.AddListener(Application.Quit);
	}

	// Update is called once per frame
	void Update () {

	}
}
