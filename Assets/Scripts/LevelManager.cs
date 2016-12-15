using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	public void LoadScene(string name) {
		Application.LoadLevel (name);
	}
	

}
