using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FaderScript : MonoBehaviour {
	private Image img;
	public bool FadeIn = false;
	public bool FadeOut = false;
	public float fadeStep = 0.05f;

	private float alpha = 0.0f;
	private bool isLast = false;
	private string levelName = "";

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {


		
		img = GetComponent<Image> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (FadeIn) {
			img.color = new Color(0,0,0, alpha);
			alpha += fadeStep * Time.deltaTime;

			if(alpha >= 1){
				FadeIn = false;
				DisablePic();
				FadeOut = true;

				if(isLast){
					Application.LoadLevelAsync(levelName);
				}
			}
		}

		if (FadeOut) {
			img.color = new Color(0,0,0, alpha);
			alpha -= fadeStep * Time.deltaTime;
			if(alpha <= 0 ){FadeOut = false;}
		}
	
	}

	public void Fade(SpriteRenderer SR, bool last, string name){
		levelName = name;
		isLast = last;
		FadeIn = true;
		spriteRenderer = SR;

	}

	void DisablePic(){
		if (spriteRenderer != null) {
			spriteRenderer.enabled = false;
		}


	}
}
