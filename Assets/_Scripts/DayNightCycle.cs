using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

	// Use this for initialization

	[SerializeField]
	private float _speed = 2f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (Vector3.right * this._speed * Time.deltaTime);
	}
}
