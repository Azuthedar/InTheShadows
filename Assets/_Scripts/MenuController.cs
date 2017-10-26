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
		if (CompareTag("NMode"))
		{
			PlayerPrefs.SetInt ("NormalMode", 1);
			SceneManager.LoadScene (1);
		}
		else if (CompareTag("TMode"))
		{
			PlayerPrefs.SetInt ("NormalMode", 0);
			SceneManager.LoadScene (1);
		}
		else if (CompareTag("ExitGame"))
		{
			Application.Quit ();
		}
	}
}
