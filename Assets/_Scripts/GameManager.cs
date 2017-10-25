using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public List<GameObject> goList;

	private bool			_inPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < goList.Count; i++)
		{
			this._inPos = goList [i].GetComponent<PlayerController> ().getInPos ();
			if (!_inPos)
				break ;
		}
		if (this._inPos)
		{
			Invoke ("InvokeLevelComplete", 5f);
		}
	}

	void SaveLevel()
	{
		if (SceneManager.GetActiveScene().name == "level_1")
		{
			PlayerPrefs.SetInt ("lvl1", 2);
			if (PlayerPrefs.GetInt("lvl2") != 2)
				PlayerPrefs.SetInt ("lvl2", 1);
		}
		else if (SceneManager.GetActiveScene().name == "level_2")
		{
			PlayerPrefs.SetInt ("lvl2", 2);
			if (PlayerPrefs.GetInt("lvl3") != 2)
				PlayerPrefs.SetInt ("lvl3", 1);
		}
		else if (SceneManager.GetActiveScene().name == "level_3")
		{
			PlayerPrefs.SetInt ("lvl3", 2);
			if (PlayerPrefs.GetInt("lvl4") != 2)
				PlayerPrefs.SetInt ("lvl4", 1);
		}
		else if (SceneManager.GetActiveScene().name == "level_4")
		{
			PlayerPrefs.SetInt ("lvl4", 2);
		}
		PlayerPrefs.Save ();
	}

	#region Invoke
	void InvokeLevelComplete()
	{
		this.SaveLevel ();
		SceneManager.LoadScene ("LevelSelect");
	}
	#endregion
}
