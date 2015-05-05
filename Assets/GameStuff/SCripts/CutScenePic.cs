using UnityEngine;
using System.Collections;

public class CutScenePic : MonoBehaviour {

	public bool last = false;
	public bool first = false;
	public int lifetime = 1;
	public GameObject previous;
	public string sceneName = "FIXME!!";



	private FaderScript Fader;
	// Use this for initialization
	void Start () {
		Fader = GameObject.Find ("Fader").GetComponent<FaderScript>();
		if (first) {
			Setup();
		}

	
	}
	
	// Update is called once per frame
	void Update () {
		if (!first) {
			//IF the previous one is hiding, play sound and setup hide
			if(previous.GetComponent<SpriteRenderer>().enabled == false){
				first = true;
				Setup ();

			}
		}
	
	}

	void Hide(){
		///*NOW DONE BELOW --*/ GetComponent<SpriteRenderer> ().enabled = false;
		Fader.Fade (GetComponent<SpriteRenderer> (), last, sceneName);

	}

	void Setup(){
		GetComponent<AudioSource> ().Play ();
		Invoke ("Hide", lifetime);
	}
}
