using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterSelection : MonoBehaviour {

	public List<GameObject> characterList;
	public int index = 0;
	// Use this for initialization
	void Start () {
		GameObject[] characters = Resources.LoadAll<GameObject> ("Chars");
		foreach (GameObject c in characters) 
		{
			GameObject _char = Instantiate(c) as GameObject;
			_char.transform.SetParent(GameObject.Find("CharacterSelect").transform);

			characterList.Add(_char);
			_char.SetActive(false);
			characterList[index].SetActive(true);
		}
	}
	
	// Update is called once per frame
	public void Next() 
	{
		characterList [index].SetActive (false);
		if (index == characterList.Count ) {
			index = 0;
		} else
		{
			index ++;
		}
		characterList [index].SetActive (true);
	}

	public void Previous() 
	{
		characterList [index].SetActive (false);
		if (index == 0) {
			index = characterList.Count -1;
		} else
		{
			index --;
		}
		characterList [index].SetActive (true);
	}
}
