using UnityEngine;
using System.Collections;

public class BackGroundScroller : MonoBehaviour {
	public GameObject tracker;
	public int SpeedDivisor = 20;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 temp = tracker.transform.position / SpeedDivisor;
		temp.z = temp.y;
		temp.y = 0;
		transform.localPosition = -temp;
	
	}
}
