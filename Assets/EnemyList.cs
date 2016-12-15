using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyList : MonoBehaviour {
	private GameObject[] characterList;
	private int index;

	// Use this for initialization
	void Start () {

		index = PlayerPrefs.GetInt ("EnemySel");
		characterList = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) 

			characterList[i] = transform.GetChild(i).gameObject;
		foreach (GameObject go in characterList)
			go.SetActive (false);
		if (characterList [index])
			characterList [index].SetActive (true);
	}

	// Update is called once per frame
	public void Left()
	{
		characterList [index].SetActive (false);
		index--;
		if (index < 0)
			index = characterList.Length - 1;

		characterList [index].SetActive (true);
	}

	public void Right()
	{
		characterList [index].SetActive (false);
		index++;
		if (index == characterList.Length)
			index = 0;

		characterList [index].SetActive (true);
	}

	public void Confirm() 
	{
		PlayerPrefs.SetInt ("EnemySel", index);


	}
}
