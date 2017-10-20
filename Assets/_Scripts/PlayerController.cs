using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization

	public GameObject	difficulty;

	[SerializeField]
	private float	_rotSpeed = 10f;
	[SerializeField]
	private float	_moveSpeed = 1f;
	[SerializeField]
	private float	_autoRotSpeed = 10f;
	private Behaviour _halo;
	private bool	_selected = false;
	private Vector3 	_initialPos;
	private Quaternion _initialRot;
	private bool	_canSelect = true;
	private bool	_rayHit = false;
	[SerializeField]
	private float	_leniency = 40f;

	void Start () {
		this._halo = (Behaviour)GetComponent("Halo");
		this._initialRot = this.transform.rotation;
		this._initialPos = this.transform.position;


		while (Quaternion.Angle(this.transform.rotation, this._initialRot) < 40)
		{
			this.initialRotation ();
		}
	}

	void Update () {
		this.moveSpecifiedGO (this.tag);
		this.checkRotation ();
	}

	void moveSpecifiedGO(string tag)
	{
		this.doRayCast ();

		if (this._rayHit)
		{
			float horizontal = Input.GetAxis("Mouse X") * Time.deltaTime;
			float vertical = Input.GetAxis("Mouse Y") * Time.deltaTime * -1;
			if (this._canSelect)
			{
				if (Input.GetMouseButton (0) && Input.GetKey (KeyCode.LeftShift) && this.difficulty.GetComponent<DifficultyController>().difficulty > 2) // Move Object
				{
					this._selected = true;
					this.transform.position = new Vector3(this.transform.position.x, Mathf.Clamp(this.transform.position.y + this._moveSpeed * vertical * -1, this._initialPos.y - 0.15f, this._initialPos.y + 0.15f), this.transform.position.z);
				}
				else if (Input.GetMouseButton (0) && Input.GetKey (KeyCode.LeftControl) && this.difficulty.GetComponent<DifficultyController>().difficulty > 1) // Rotate Vertically
				{
					this._selected = true;
					this.transform.Rotate (new Vector3 (vertical * this._rotSpeed, 0));
				}
				else if (Input.GetMouseButton (0)) // Rotate Horizontally
				{
					this._selected = true;
					this.transform.Rotate (new Vector3 (0, horizontal * this._rotSpeed));
				}

			}
			if (!Input.GetMouseButton (0))
			{
				this._rayHit = false;
				this._selected = false;
			}
			
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

	void doRayCast()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				if (hit.collider.tag == tag)
				{
					this._rayHit = true;
				}
			}
		}
	}

	void checkRotation()
	{
		float offset_x = Mathf.Abs(Mathf.DeltaAngle (this._initialRot.x, transform.rotation.eulerAngles.x));
		float offset_y = Mathf.Abs(Mathf.DeltaAngle (this._initialRot.y, transform.rotation.eulerAngles.y));
		if ((offset_x <= this._leniency || offset_x >= 180 - this._leniency) && offset_y <= this._leniency)
		{
			this._canSelect = false;
			Invoke ("InvokeLevelComplete", 5f);
		}
		if (!this._canSelect)
		{
			this.transform.rotation = Quaternion.RotateTowards (this.transform.rotation, this._initialRot, this._autoRotSpeed * Time.deltaTime);
			this.transform.position = Vector3.MoveTowards (this.transform.position, this._initialPos, this._moveSpeed / 4 * Time.deltaTime);
		}
		
	}
#region Difficulty handlers
	void initialRotation()
	{
		if (this.difficulty.GetComponent<DifficultyController>().difficulty == 1)
		{
			this.transform.rotation = Quaternion.Euler (0, Random.Range (0.0f, 360.0f), 0);
		}
		else if (this.difficulty.GetComponent<DifficultyController>().difficulty == 2)
		{
			this.transform.rotation = Quaternion.Euler (Random.Range (0.0f, 360.0f), Random.Range (0.0f, 360.0f), 0);
		}
		else if (this.difficulty.GetComponent<DifficultyController>().difficulty == 3)
		{
			this.transform.rotation = Quaternion.Euler (Random.Range (0.0f, 360.0f), Random.Range (0.0f, 360.0f), 0);
		}

	}
#endregion

#region Invoke
	void InvokeLevelComplete()
	{
		Debug.Log ("Level Completed");
	}
#endregion
}
