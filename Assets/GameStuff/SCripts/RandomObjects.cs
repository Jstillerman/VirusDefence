using UnityEngine;
using System.Collections;

public class RandomObjects : MonoBehaviour {
	public int chance = 100;
	public GameObject prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Floor (Random.Range (0, chance)) == 2) {
	
			GameObject obj = Instantiate(prefab, transform.position, new Quaternion(0,0,0,0)) as GameObject;
			Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

			rb.AddForce(new Vector2(Random.Range(-0.5f, 0.5f), Random.Range (-0.5f, 0.5f)));



		}
	
	}
}
