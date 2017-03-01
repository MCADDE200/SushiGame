//using UnityEngine;
//using System.Collections;
//
//public class PlayerFightingScript : MonoBehaviour {
//
//	PlayerScript playerScript;
//	Player2Script player2Script;
//	Player3Script player3Script;
//
//    static GameObject player1 = GameObject.Find("Player1");
//    static GameObject player2 = GameObject.Find("Player2");
//    static GameObject player3 = GameObject.Find("Player3");
//
//    public float player1PosX = player1.transform.position.x;
//    public float player2PosX = player2.transform.position.x;
//    public float player3PosX = player3.transform.position.x;
//
////	public GameObject player1;
////	public GameObject player2;
////	public GameObject player3;
//
//	void OnEnable ()
//	{
//		playerScript = GetComponent<PlayerScript> ();
//		playerScript.onCheckAttack += checkPlayer1Attack;
//
//		player2Script = GetComponent<Player2Script> ();
//		player2Script.onCheckAttack += checkPlayer2Attack;
//
//		player3Script = GetComponent<Player3Script> ();
//		player3Script.onCheckAttack += checkPlayer3Attack;
//
//	}
//
//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//
//	void checkPlayer1Attack()
//	{
//		
//        //GameObject player1 = GameObject.Find ("Player1");
//        //GameObject player2 = GameObject.Find ("Player2");
//        //GameObject player3 = GameObject.Find ("Player3");
//
//        //if (player1 != null)
//        //{
//        //    float player1PosX = player1.transform.position.x;
//        //}
//        //if (player2 != null)
//        //{
//        //    float player2PosX = player2.transform.position.x;
//        //}
//        //if (player3 != null)
//        //{
//        //    float player3PosX = player3.transform.position.x;
//        //}
//
//        //float player1PosX = player1.transform.position.x;
//        //float player2PosX = player2.transform.position.x;
//        //float player3PosX = player3.transform.position.x;
//		
//
//
//		Debug.Log ("Events!");
//        if (player2 != null)
//        {
//            if (Mathf.Abs(player1PosX - player2PosX) < 0.2)
//            {
//                Destroy(player2);
//            }
//        }
//		if (player3 != null)
//        {
//            if (Mathf.Abs(player1PosX - player3PosX) < 0.2)
//            {
//                Destroy(player3);
//            }
//        }
//		
//	}
//
//	void checkPlayer2Attack()
//	{
//
//        //GameObject player1 = GameObject.Find ("Player1");
//        //GameObject player2 = GameObject.Find ("Player2");
//        //GameObject player3 = GameObject.Find ("Player3");
//
//        //float player1PosX = player1.transform.position.x;
//        //float player2PosX = player2.transform.position.x;
//        //float player3PosX = player3.transform.position.x;
//
//
//		Debug.Log ("Events!");
//        if (player1 != null)
//        {
//            if (Mathf.Abs(player2PosX - player1PosX) < 0.2)
//            {
//                Destroy(player1);
//            }
//        }
//        if (player3 != null)
//        {
//            if (Mathf.Abs(player2PosX - player3PosX) < 0.2)
//            {
//                Destroy(player3);
//            }
//        }
//	}
//
//	void checkPlayer3Attack()
//	{
//
//        //GameObject player1 = GameObject.Find ("Player1");
//        //GameObject player2 = GameObject.Find ("Player2");
//        //GameObject player3 = GameObject.Find ("Player3");
//
//        //float player1PosX = player1.transform.position.x;
//        //float player2PosX = player2.transform.position.x;
//        //float player3PosX = player3.transform.position.x;
//
//
//		Debug.Log ("Events!");
//        if (player2 != null)
//        {
//            if (Mathf.Abs(player3PosX - player2PosX) < 0.2)
//            {
//                Destroy(player2);
//            }
//        }
//        if (player1 != null)
//        {
//            if (Mathf.Abs(player3PosX - player1PosX) < 0.2)
//            {
//                Destroy(player3);
//            }
//        }
//	}
//
//	void OnDisable()
//	{
//		playerScript.onCheckAttack -= checkPlayer1Attack;
//	}
//}
