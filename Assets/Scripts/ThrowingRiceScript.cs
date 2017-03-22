using UnityEngine;
using System.Collections;

public class ThrowingRiceScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		GameObject gameData = GameObject.Find ("GameData");
		if (gameData != null) {
			GameDataScript gameDataScript = gameData.GetComponent<GameDataScript> ();
			GameObject player1 = GameObject.Find ("Player1");
			if (player1 != null) {
				PlayerScript playerScript = player1.GetComponent<PlayerScript> ();
				if (playerScript.p1Throw == true) {
					GetComponent<Rigidbody2D> ().AddForce (new Vector2 (gameDataScript.p1riceSpeed, 0.0f));
					playerScript.p1Throw = false;
				}
			}
			GameObject player2 = GameObject.Find ("Player2");
			if (player2 != null) {
				Player2Script player2Script = player2.GetComponent<Player2Script> ();
				if (player2Script.p2Throw == true) {
					GetComponent<Rigidbody2D> ().AddForce (new Vector2 (gameDataScript.p2riceSpeed, 0.0f));
					player2Script.p2Throw = false;
				}
			}
		}
		StartCoroutine (BulletDelayedDestroy ());
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator BulletDelayedDestroy (){
		yield return new WaitForSeconds (1.5f);
		Destroy (gameObject);
	}
		

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Equals("Player1")) {
			GameObject player1 = GameObject.Find ("Player1");
			if (player1 != null) {
				PlayerScript playerScript = player1.GetComponent<PlayerScript> ();
				playerScript.stuck = true;
			}
			//Destroy (gameObject);
		}

		if (other.gameObject.name.Equals("Player2")) {
			GameObject player2 = GameObject.Find ("Player2");
			if (player2 != null) {
				Player2Script player2Script = player2.GetComponent<Player2Script> ();
				player2Script.stuck = true;
			}
			//Destroy (gameObject);
		}

		if (other.gameObject.name.Equals("Player3")) {

		}

		if (other.gameObject.name.Equals("Player4")) {

		}
			
	}
}