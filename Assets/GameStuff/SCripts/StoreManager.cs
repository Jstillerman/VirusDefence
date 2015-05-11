using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class StoreManager : MonoBehaviour {

	public bool[] slotEnabled = {true, false, false};
	public string[] slotContent = {"Empty", "Empty", "Empty"};
	public GameObject Slot1;
	public GameObject Slot2;
	public GameObject Slot3;
	public Texture[] textures;
	public string[] items;

	

	public Canvas OverViewCanvas;
	public Canvas EditGadgetCanvas;
	public int coins = 0;

	private RawImage gadgetSlot1;
	private IOMenuManager IOMenMan;
	// Use this for initialization
	void Start () {
		IOMenMan = GetComponent<IOMenuManager> ();
		IOMenMan.LoadCoins ();

		coins = IOMenMan.coins;


		gadgetSlot1 = Slot1.GetComponent<RawImage> ();





	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	void EditGadgets(){
		OverViewCanvas.enabled = false;
		EditGadgetCanvas.enabled = true;
	
	}

	public void BackToMain(){
		EditGadgetCanvas.enabled = false;
		OverViewCanvas.enabled = true;
	}

	public void equipt(string itemName){
		Debug.Log ("putting a " + itemName + " in slot 1");
		gadgetSlot1.texture = textures[System.Array.IndexOf (items, itemName)];
		slotContent [0] = itemName;
	}
}
