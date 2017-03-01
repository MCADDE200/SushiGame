using UnityEngine;
using System.Collections;

public class InitialiseScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject gameData = GameObject.Find ("GameData");
		if (gameData == null) 
		{
			gameData = new GameObject ("GameData");
			gameData.AddComponent<GameDataScript> ();

		} 
	}

	// Update is called once per frame
	void Update () {

	}
}
