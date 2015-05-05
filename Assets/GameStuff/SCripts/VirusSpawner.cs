using UnityEngine;
using System.Collections;

public class VirusSpawner : MonoBehaviour {
	public int spawnRate = 1;
	public GameObject StandardPrefab;
	public GameObject MutePrefab;


	private GameManagerScript GameManager;
	
	// Use this for initialization
	void Start () {
		GameObject temp = GameObject.Find ("GameManager");
		GameManager = temp.GetComponent<GameManagerScript> ();
		InvokeRepeating ("makeVirus", 0f, spawnRate);

	}

 	GameObject getPrefab(){
		string name = GameManager.nextVirus ();
		switch (name) {
		case "Standard":
			return StandardPrefab;
			break;
		case "Mute":
			return MutePrefab;
			break;

		default:
			GameObject temp = new GameObject ();
			temp.tag = "empty";
			return temp;

		}


	}

		void makeVirus(){
			GameObject thePrefab = getPrefab ();
			if(thePrefab.tag != "empty"){
			GameObject obj = Instantiate(thePrefab, transform.position, new Quaternion(0,0,0,0)) as GameObject;
			Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
			
			rb.AddForce(new Vector2(Random.Range(-0.5f, 0.5f), Random.Range (-0.5f, 0.5f)));
			
		}
		
	}
}
