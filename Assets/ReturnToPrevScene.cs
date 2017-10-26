using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToPrevScene : MonoBehaviour {

	// Use this for initialization

	private Vector3 _initPos;

	private bool	_shouldMove = false;

	void Start () {
		this._initPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (this._shouldMove)
		{
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Mathf.Lerp (this.transform.position.z, this._initPos.z, 0.1f));
		}
		if (Vector3.Distance(this.transform.position, this._initPos) == 0)
		{
			this._shouldMove = false;
		}
	}

	void OnMouseOver()
	{
		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Mathf.Lerp (this.transform.position.z, this._initPos.z - 0.7f, 0.1f));
		if (Input.GetMouseButtonDown (0))
		{
			SceneManager.LoadScene ("MainMenu");
		}
	}

	void OnMouseExit()
	{
		this._shouldMove = true;
	}
}
