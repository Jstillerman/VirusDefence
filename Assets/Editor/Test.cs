using UnityEngine;
using System.Collections;
using UnityEditor;

public class Test : Editor {

	[MenuItem("Scenes/Menu")]
	public static void OpenSceneMenu(){
		OpenScene ("Menu");
	}


	public static void OpenScene(string name){
		if (EditorApplication.SaveCurrentSceneIfUserWantsTo ()) {
			EditorApplication.OpenScene("Assets/GameStuff/Scenes/" + name + ".unity");
		}
	}

}
