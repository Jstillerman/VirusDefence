using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	public string GameSceneName = "";
	public string LevelSelectSceneName ="";
	public string StoreSceneName = "";
	// Use this for initialization
	void Start () {
		GameSceneName = GetComponent<IOMenuManager> ().getCurrentLevel();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void NextScene(){
		Application.LoadLevel (GameSceneName);
	}

	void LevelSelectScene(){
		Application.LoadLevel (LevelSelectSceneName);
	}

	void StoreScene(){
		Application.LoadLevel (StoreSceneName);
	}
}
