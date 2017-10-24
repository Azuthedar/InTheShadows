using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	private Button button;

	void Start()
	{
		button = GetComponent<Button> ();
		button.onClick.AddListener (OnClick);
	}

	void OnClick()
	{
		Debug.Log ("Clicked");
		if (CompareTag("NMode"))
		{
			SceneManager.LoadScene (1);
		}
		else if (CompareTag("TMode"))
		{
			//TODO: Load saved Scenemanager INDEX
		}
		else if (CompareTag("ExitGame"))
		{
			Application.Quit ();
		}
	}
}
