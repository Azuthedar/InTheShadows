using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization

	[SerializeField]
	private float	_rotSpeed = 10f;
	[SerializeField]
	private float	_autoRotSpeed = 10f;
	private Behaviour _halo;
	private bool	_selected = false;
	private Quaternion _initialRot;
	private bool	_canSelect = true;

	void Start () {
		this._halo = (Behaviour)GetComponent("Halo");
		this._initialRot = this.transform.rotation;
		this.transform.rotation = Quaternion.Euler (Random.Range (0.0f, 360.0f), Random.Range (0.0f, 360.0f), 0);
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("Current: " + Mathf.Cos (this.transform.rotation.z)+ "\nInitial: " + Mathf.Cos (this._initialRot.z));

		this.moveSpecifiedGO (this.tag);
		this.checkRotation ();
	}

	void moveSpecifiedGO(string tag)
	{
		if (CompareTag(tag))
		{
			float horizontal = Input.GetAxis("Mouse X") * this._rotSpeed * Time.deltaTime;
			float vertical = Input.GetAxis("Mouse Y") * this._rotSpeed * Time.deltaTime * -1;
			if (this._canSelect)
			{
				if (Input.GetMouseButton (0) && Input.GetKey (KeyCode.LeftShift)) // Move Object
				{
					this._selected = true;
					//TODO: MOVE OBJECT	
				}
				else if (Input.GetMouseButton (0) && Input.GetKey (KeyCode.LeftControl)) // Rotate Vertically
				{
					this._selected = true;
					this.transform.Rotate (new Vector3 (vertical, 0));
				}
				else if (Input.GetMouseButton (0)) // Rotate Horizontally
				{
					this._selected = true;
					this.transform.Rotate (new Vector3 (0, horizontal));
				}

			}
			if (!Input.GetMouseButton (0))
				this._selected = false;
			
			if (this._selected)
			{
				this._halo.enabled = true;
			}
			else
			{
				this._halo.enabled = false;
			}
		}
	}

	void checkRotation()
	{
		float angle = Quaternion.Angle (this.transform.rotation, this._initialRot);

		if (Mathf.Abs(angle) <= 40f)
		{
			Debug.Log ("AutoRotating");
			this._canSelect = false; // Remove control from the player

			this.transform.rotation = Quaternion.RotateTowards (this.transform.rotation, this._initialRot, this._autoRotSpeed * Time.deltaTime);
		}
		if (Mathf.Abs(angle) == 0f)
		{
			Debug.Log ("Level Completed");
		}
	}

//	void OnMouseOver()
//	{
//		GetComponent<Renderer>().material.shader = Shader.Find("Particles/VertexLit Blended");
//	}
//
//	void OnMouseExit()
//	{
//		GetComponent<Renderer>().material.shader = Shader.Find("Standard");
//	}
}
