using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {

	// Use this for initialization

	private bool		_isLocked = true;
	private bool		_isCompleted = false;

	private Color		_completedColor;
	private Color 		_lockedColor;
	private Color		_availableColor;

	void Start ()
	{
		this._completedColor = new Color (0.3f, 1f, 0.2f);
		this._lockedColor = new Color (1f, 0.3f, 0.3f);
		this._availableColor = new Color (0.4f, 0.4f, 1.0f);

		if (this.name == "lvl1")
		{
			this._isLocked = false;
		}
		if (this.name == "lvl2")
		{
			this._isLocked = false;
			this._isCompleted = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (this._isLocked)
		{
			this.GetComponent<Renderer> ().material.color = this._lockedColor;
		}
		else if (!this._isLocked && !this._isCompleted)
		{
			this.GetComponent<Renderer> ().material.color = this._availableColor;
		}
		else if (this._isCompleted)
		{
			this.GetComponent<Renderer> ().material.color = this._completedColor;
		}
		this.SelectLevel ();

	}

	void SelectLevel()
	{
		if (Input.GetMouseButtonDown (0))
		{
			Ray ray = new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit))
			{
				if (hit.collider.name == "lvl1")
				{
					SceneManager.LoadScene ("level_1");
				}
				else if (hit.collider.name == "lvl2")
				{
					SceneManager.LoadScene ("level_2");
				}
				else if (hit.collider.name == "lvl3")
				{
					SceneManager.LoadScene ("level_3");
				}
				else if (hit.collider.name == "lvl4")
				{
					SceneManager.LoadScene ("level_4");
				}
				
			}
		}
	}

	void OnMouseEnter()
	{
		gameObject.GetComponent<Renderer> ().material.color = new Color (0.5f, 0.5f, 0.5f);
	}

	void OnMouseExit()
	{
		gameObject.GetComponent<Renderer> ().material.color = new Color (1f, 1f, 1f);
	}
}
