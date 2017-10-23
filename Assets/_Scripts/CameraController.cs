using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization

	private Camera 	_cam;
	[SerializeField]
	private float	_zoomSpeed;

	void Start () {
		this._cam = GetComponent<Camera> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Z))
		{
			this._cam.fieldOfView = Mathf.Lerp (this._cam.fieldOfView, 20, this._zoomSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.A))
		{
			this._cam.fieldOfView = Mathf.Lerp (this._cam.fieldOfView, 60, this._zoomSpeed * Time.deltaTime);
		}
	}
}
