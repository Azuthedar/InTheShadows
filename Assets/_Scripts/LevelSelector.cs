using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {

	// Use this for initialization

	private bool		_isLocked = true;
	private bool		_isCompleted = false;
	private bool		_shouldRotate = false;

	private Color		_completedColor;
	private Color 		_lockedColor;
	private Color		_availableColor;

	private Quaternion	_initRot;

	void Start ()
	{
		this._initRot = this.transform.rotation;

		this._completedColor = new Color (0.3f, 1f, 0.2f);
		this._lockedColor = new Color (1f, 0.3f, 0.3f);
		this._availableColor = new Color (0.4f, 0.4f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.CheckPlayerPref ();

		if (this._isLocked)
		{
			this.GetComponent<Renderer> ().material.color = this._lockedColor;
		}
		if (!this._isLocked && !this._isCompleted)
		{
			this.GetComponent<Renderer> ().material.color = this._availableColor;
		}
		if (this._isCompleted)
		{
			this.GetComponent<Renderer> ().material.color = this._completedColor;
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			PlayerPrefs.DeleteAll ();
		}

		if (this._shouldRotate)
		{
			this.transform.rotation = Quaternion.RotateTowards (this.transform.rotation, this._initRot, 1f);
		}
		if (Quaternion.Angle(this.transform.rotation, this._initRot) == 0)
		{
			this._shouldRotate = false;
		}
	}



	void OnMouseEnter()
	{
		gameObject.GetComponent<Renderer> ().material.color = new Color (0.5f, 0.5f, 0.5f);
	}

	void OnMouseExit()
	{
		this._shouldRotate = true;
		gameObject.GetComponent<Renderer> ().material.color = new Color (1f, 1f, 1f);
	}

	void OnMouseOver()
	{
		this.transform.Rotate (Vector3.forward * 2f);
		if (Input.GetMouseButtonDown (0))
		{
			if (!this._isLocked)
			{
				Debug.Log ("Not Locked, possibly completed");
				if (this.name == "lvl1")
				{
					SceneManager.LoadScene ("level_1");
				}
				else if (this.name == "lvl2")
				{
					SceneManager.LoadScene ("level_2");
				}
				else if (this.name == "lvl3")
				{
					SceneManager.LoadScene ("level_3");
				}
				else if (this.name == "lvl4")
				{
					SceneManager.LoadScene ("level_4");
				}
			}
		}
	}

	void CheckPlayerPref()
	{
		if (PlayerPrefs.GetInt ("NormalMode", 0) == 1)
		{
			if (PlayerPrefs.GetInt ("lvl1", 1) >= 1 && this.name == "lvl1")
			{
				this._isLocked = false;
			}
			if (PlayerPrefs.GetInt ("lvl2", 0) >= 1 && this.name == "lvl2")
			{
				this._isLocked = false;
			}
			if (PlayerPrefs.GetInt ("lvl3", 0) >= 1 && this.name == "lvl3")
			{
				this._isLocked = false;
			}
			if (PlayerPrefs.GetInt ("lvl4", 0) >= 1 && this.name == "lvl4")
			{
				this._isLocked = false;
			}

			if (PlayerPrefs.GetInt ("lvl1", 1) == 2 && this.name == "lvl1")
			{
				this._isCompleted = true;
			}
			if (PlayerPrefs.GetInt ("lvl2", 0) == 2 && this.name == "lvl2")
			{
				this._isCompleted = true;
			}
			if (PlayerPrefs.GetInt ("lvl3", 0) == 2 && this.name == "lvl3")
			{
				this._isCompleted = true;
			}
			if (PlayerPrefs.GetInt ("lvl4", 0) == 2 && this.name == "lvl4")
			{
				this._isCompleted = true;
			}
		}
		else
		{
			this._isLocked = false;
			this._isCompleted = true;
		}
	}
}
