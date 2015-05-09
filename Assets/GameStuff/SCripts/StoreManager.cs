using UnityEngine;
using System.Collections;

public class StoreManager : MonoBehaviour {

	public Canvas OverViewCanvas;
	public Canvas EditGadgetCanvas;
	public int coins = 0;

	private IOMenuManager IOMenMan;
	// Use this for initialization
	void Start () {
		IOMenMan = GetComponent<IOMenuManager> ();
		IOMenMan.LoadCoins ();

		coins = IOMenMan.coins;


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void EditGadgets(){
		OverViewCanvas.enabled = false;
		EditGadgetCanvas.enabled = true;
	
	}
}
