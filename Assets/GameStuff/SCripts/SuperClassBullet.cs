using UnityEngine;
using System.Collections;

public class SuperClassBullet : MonoBehaviour{
	public int damage = 1;
	public int speed = 400;
	public float accuracy = 0.1f;
	public int lifetime = 2;

	// Use this for initialization
	void Start () {
		tag = "bullet";
		Destroy (gameObject, lifetime);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
	}

	void init(){


	}

	public float getMass(){
		return GetComponent<Rigidbody2D> ().mass;
	}

	
}
