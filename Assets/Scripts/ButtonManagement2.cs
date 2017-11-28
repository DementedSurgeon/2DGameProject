using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManagement2 : MonoBehaviour {

	public Button startButton;
	public Button quitButton;
	public Button retryButton;
	private PlayerSounds pSounds;

	// Use this for initialization
	void Start () {
		pSounds = gameObject.GetComponent<PlayerSounds> ();
		startButton.onClick.AddListener(delegate() {
			SceneManager.LoadScene("TitleScreen");
			pSounds.Play(0);
		});
		quitButton.onClick.AddListener(Application.Quit);
		if (retryButton != null) {
			retryButton.onClick.AddListener (delegate() {
				SceneManager.LoadScene ("SD");
				pSounds.Play(0);
			});
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
