using UnityEngine;
using System.Collections;

public class IOMenuManager : MonoBehaviour {
	public int coins = 0;

	
	private static string CoinFilePath;
	private static string LevelFilePath;
	
	
	
	// Use this for initialization
	void Start () {
		CoinFilePath= Application.persistentDataPath + "/x11_gm.dll";
		LevelFilePath= Application.persistentDataPath + "/win_gm.dll";
		
		
		if (System.IO.File.Exists (CoinFilePath)) {
			LoadCoins();
		} else {
			Debug.Log ("No coin file found, I created one at " + CoinFilePath);
			System.IO.File.Create (CoinFilePath).Close();
			SetCoins(10);
		}
		
		if (!System.IO.File.Exists (LevelFilePath)) {
			System.IO.File.Create (LevelFilePath).Close ();
			setLevel("CutScene1");
			Debug.Log("there was no level file, I i created it.");
			
		}
		
		
	
		
		
	}
	
	void Update () {
		
		
	}
	
	public void SetCoins(int numCoins){
		
		System.IO.File.WriteAllText(CoinFilePath, (numCoins).ToString());
	}
	
	
	void LoadCoins(){
		System.IO.StreamReader temp = System.IO.File.OpenText(CoinFilePath);
		string file = temp.ReadToEnd();
		temp.Close ();
		//try{GetComponent<GameManagerScript>().coins = int.Parse(file);}
		//catch{SetCoins(10); LoadCoins();}
		
		Debug.Log ("Loaded Coins: " + file);
		
	}
	
	public string getCurrentLevel(){
		System.IO.StreamReader file = System.IO.File.OpenText (LevelFilePath);
		string sceneName = file.ReadToEnd ();
		file.Close ();
		return sceneName;
		//return "CutScene1";
	}
	
	public void setLevel(string newLevelName){
		System.IO.File.WriteAllText (LevelFilePath, newLevelName);
	}
}
