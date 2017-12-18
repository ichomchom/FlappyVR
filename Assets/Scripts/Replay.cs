using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Replay : MonoBehaviour {
   
	public Button ourButton;

	void Start () {
		Button btn = ourButton.GetComponent<Button>();
		btn.onClick.AddListener(PlayAgain);
	}


	public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }
}
