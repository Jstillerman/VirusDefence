using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {



		Vector3 temp = player.transform.position;
		temp.z = transform.position.z;

		transform.position = temp;
	
	}
}
