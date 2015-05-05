using UnityEngine;
using System.Collections;
using SimpleJSON;
public class GameManagerScript : MonoBehaviour {
	public int LiveViruses = 0;
	public int coins = 0;
	public TextAsset waves;
	public int WaveNumber = 0;
	public int NumberOfWaves = 1000;
	public int LevelNumber = 1;
	public string procedingLevel = "CutScene1";
	public bool gameOver = false;
	public bool canreturntomenu = true;

	private Canvas WaveCompleteCanvas;
	private Canvas WinCanvas;
	private Canvas LoseCanvas;
	private JSONNode N;

	public int viruscount = 0;
	public ArrayList CurrentVirusList = new ArrayList();
	// Use this for initialization
	void Start () {


		GameObject tmp = GameObject.Find("LevelCompleteCanvas");
		WinCanvas = tmp.GetComponent<Canvas> ();

		tmp = GameObject.Find("LevelLoseCanvas");
		LoseCanvas = tmp.GetComponent<Canvas> ();

		tmp = GameObject.Find("WaveCompleteCanvas");
		WaveCompleteCanvas = tmp.GetComponent<Canvas> ();

		WaveCompleteCanvas.enabled = false;
		WinCanvas.enabled = false;
		LoseCanvas.enabled = false;


		//Load in the waves
		N = JSON.Parse(waves.text);


		NumberOfWaves = N ["Settings"] ["NumberOfWaves"].AsInt;

		UpdateVirusList ();
	
	}
	
	// Update is called once per frame
	void Update () {

	
		//IF NEXT WAVE
		if (viruscount >= CurrentVirusList.Count && LiveViruses == 0 && WaveCompleteCanvas.enabled == false && WinCanvas.enabled == false) {
		
				WaveCompleteCanvas.enabled = true;
				NextWave();
				Invoke("WaveCompleteGUI", 1f);

		}
		//IF WIN
		if (LiveViruses <= 0 && WaveNumber >= NumberOfWaves) {
			gameOver = true;
			WinCanvas.enabled = true;
			Invoke("CompleteLevel", 2f);

		}

		//IF LOSE
		if (GameObject.FindGameObjectsWithTag ("base").GetLength(0) == 0) {
			gameOver = true;
			LoseCanvas.enabled = true;
			Invoke("LoseLevel", 2f);

		}

	
	}
	public string nextVirus(){
		if (viruscount < CurrentVirusList.Count) {
			viruscount++;
			return CurrentVirusList [viruscount - 1] as string;
		}

		return "Nothing";
		//Virus count-1 becuase the index has to start at 0

	}

	void UpdateVirusList(){

		//Populate CurrentVirusList with String containing its name
		for (int i = 0; i < N["VirusTypes"].Count; i ++) {
			string type = N ["VirusTypes"] [i];
			for(int j = 0; j < N["Waves"][WaveNumber][type].AsInt; j++){
				CurrentVirusList.Add (type);
			}
		}



	}

	void NextWave(){
		WaveNumber++;
		CurrentVirusList.Clear ();
		viruscount = 0;
		UpdateVirusList ();
		Debug.Log("NEW WAVE!!!!!");
	}

	void CompleteLevel(){
		//GetComponent<IOManager> ().SetCoins (coins);
		//GetComponent<IOManager>().setLevel(procedingLevel);
		ReturnToMenu ();



	}

	void LoseLevel(){
		GetComponent<IOManager> ().SetCoins (coins);
		ReturnToMenu ();

	}

	void WaveCompleteGUI(){
			WaveCompleteCanvas.enabled = false;

	}

	void ReturnToMenu(){
		if (canreturntomenu) {
			AsyncOperation async = Application.LoadLevelAsync (1);
			Debug.Log (async.progress);
			canreturntomenu = false;
		}
	}
	
	
}
