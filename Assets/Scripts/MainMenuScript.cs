using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadGame(){
		Application.LoadLevel ("Level1");
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
