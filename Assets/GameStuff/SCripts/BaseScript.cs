using UnityEngine;
using System.Collections;

public class BaseScript : MonoBehaviour {
	public int StartingLife = 100;
	public int GUIPadding = 30;

	private int life = 100;
	private float ratio = 0.75f;

	// Use this for initialization
	void Start () {
	
		life = StartingLife;
	}
	
	// Update is called once per frame
	void Update () {
		ratio = life * 1.0f / StartingLife;
	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag == "virus") {
			life -= coll.gameObject.GetComponent<SuperClassVirus>().getDamage();
		}


		if (life <= 0) {

			Destroy (gameObject);


		}


	}

	void OnGUI () {

		int barheight = Screen.height / 20;
		int barwidth = Screen.width;

		// Create one Group to contain both images
		// Adjust the first 2 coordinates to place it somewhere else on-screen
		GUI.BeginGroup (new Rect (0, 0 ,barwidth,barheight));
		GUI.color = Color.red;
		// Draw the background image
		GUI.Box (new Rect (0,0,barwidth,barheight), "Life");
		
		
		// Create a second Group which will be clipped
		// We want to clip the image and not scale it, which is why we need the second Group
		GUI.BeginGroup (new Rect (0,0, ratio * barwidth, barheight));
		GUI.color = Color.green;
		// Draw the foreground image
		GUI.Box (new Rect (0,0,barwidth,barheight), "Life");
		
		// End both Groups
		GUI.EndGroup ();
		
		GUI.EndGroup ();
	}
}
