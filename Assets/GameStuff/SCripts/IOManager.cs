using UnityEngine;
using System.Collections;
using SimpleJSON;

public class IOManager : MonoBehaviour {

	private static string CoinFilePath;
	private static string LevelFilePath;


	// Use this for initialization
	void Start () {
		CoinFilePath= Application.persistentDataPath + "/x11_gm.dll";
		LevelFilePath= Application.persistentDataPath + "/win_gm.dll";

	//	System.IO.File.Create (CoinFilePath).Close();
	//	System.IO.File.Create (LevelFilePath).Close();
		//Put coins from file into GameManager's coins
		//	LoadCoins (System.IO.File.OpenText (CoinFilePath).ReadToEnd());


	
	}

	void Update () {

	
	}

	public void SetCoins(int numCoins){
													
		//System.IO.File.WriteAllText(CoinFilePath, (numCoins).ToString());
	}


	void LoadCoins(string file){
			try{GetComponent<GameManagerScript>().coins = int.Parse(file);}
			catch{SetCoins(10); LoadCoins("10");}

			Debug.Log ("Loaded Coins: " + file);
		
	}

	public string getCurrentLevel(){
		//return System.IO.File.OpenText (LevelFilePath).ReadToEnd ();
		return "CutScene1";
	}

	public void setLevel(string newLevelName){
		//System.IO.File.WriteAllText (LevelFilePath, newLevelName);
	}
}

