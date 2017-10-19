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
		if (CompareTag("NewGame"))
		{
			SceneManager.LoadScene (0);
		}
		else if (CompareTag("LoadGame"))
		{
			//TODO: Load saved Scenemanager INDEX
		}
		else if (CompareTag("Settings"))
		{
			//TODO: Go to settings Menu
		}
		else if (CompareTag("ExitGame"))
		{
			Application.Quit ();
		}
	}
}
