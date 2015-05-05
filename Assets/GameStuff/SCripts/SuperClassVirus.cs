using UnityEngine;
using System.Collections;

public class SuperClassVirus : MonoBehaviour {
	public int life = 10;
	public int damage = 1;
	public int attackdelay = 5;
	public Vector3 target = new Vector3 (0, 0, 0);
	public int dropNumber = 1;
	public GameObject CoinType;

	private GameManagerScript GameManager;
	private Rigidbody2D rb;
	private int attackcount = 0;
	// Use this for initialization
	void Start () {
		tag = "virus";
		rb = GetComponent<Rigidbody2D> ();
		GameManager = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();

		//target = GameObject.Find ("base").transform.position;
		GameManager.LiveViruses++;

	}


	void Die(){
		for (int i = 0; i < dropNumber; i++) {
			GameObject coin = Instantiate(CoinType, transform.position, new Quaternion(0,0,0,0)) as GameObject;
			coin.GetComponent<Rigidbody2D>().AddForce(randomVect());
		}
		GameManager.LiveViruses--;
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (life <= 0) {
			Die();
		}

		rb.AddForce (target - transform.position);

	try{
		target = GameObject.FindGameObjectsWithTag ("base") [0].transform.position;
		}
		catch{Debug.Log("The Base was not found");}

		if (GameManager.gameOver) {
			Destroy(gameObject);
		}

	}

	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "bullet") {

			life -= coll.gameObject.GetComponent<SuperClassBullet>().damage;
			Destroy(coll.gameObject);
		}



	}

	public int getDamage(){
		attackcount++;
		if (attackcount >= attackdelay) {
			attackcount = 0;
			return damage;
		}
		return 0;

	}

	Vector3 randomVect(){
		return new Vector3(Random.Range (-1, 1), Random.Range (-1, 1), Random.Range (-1, 1));
	}


}
