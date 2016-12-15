using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterList : MonoBehaviour {
	private GameObject[] characterList;
	private int index;

	// Use this for initialization
	void Start () {

		index = PlayerPrefs.GetInt ("CharacterSelected");
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
		PlayerPrefs.SetInt ("CharacterSelected", index);
		SceneManager.LoadScene ("pangmalupitan");

	}

	public void Confirm2() 
	{
		PlayerPrefs.SetInt ("CharacterSelected", index);
		SceneManager.LoadScene ("Stage2");

	}

	public void Confirm3() 
	{
		PlayerPrefs.SetInt ("CharacterSelected", index);
		SceneManager.LoadScene ("Stage3");

	}

	public void Confirm4() 
	{
		PlayerPrefs.SetInt ("CharacterSelected", index);
		SceneManager.LoadScene ("Stage4");
	
	}

	public void Confirm5() 
	{
		PlayerPrefs.SetInt ("CharacterSelected", index);
		SceneManager.LoadScene ("Stage5");


	}

	public void Confirm6() 
	{
		PlayerPrefs.SetInt ("CharacterSelected", index);
		SceneManager.LoadScene ("Stage6");

	}

	public void Confirm7() 
	{
		PlayerPrefs.SetInt ("CharacterSelected", index);
		SceneManager.LoadScene ("Stage7");

	}

	public void Confirm8() 
	{
		PlayerPrefs.SetInt ("CharacterSelected", index);
		SceneManager.LoadScene ("Stage8");

	}

	public void Confirm9() 
	{
		PlayerPrefs.SetInt ("CharacterSelected", index);
		SceneManager.LoadScene ("Stage9");

	}

	public void Confirm10() 
	{
		PlayerPrefs.SetInt ("CharacterSelected", index);
		SceneManager.LoadScene ("Stage10");

	}
}
