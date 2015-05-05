using UnityEngine;
using System.Collections;

public class coinScript : MonoBehaviour {
	public int value = 1;
	GameManagerScript gameManager;
	// Use this for initialization
	void Start () {
		GameObject temp = GameObject.Find("GameManager");
		gameManager = temp.GetComponent<GameManagerScript> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		switch (coll.gameObject.tag) {
		case "bullet":
			Destroy(coll.gameObject);
			gameManager.coins += value;
			Destroy(gameObject);
			break;
		case "Player":
			gameManager.coins += value;
			Destroy(gameObject);
			break;
		}


	}
}
