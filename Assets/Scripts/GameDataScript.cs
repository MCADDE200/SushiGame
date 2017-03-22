using UnityEngine;
using System.Collections;

public class GameDataScript : MonoBehaviour {

	public int player1Score = 0;
	public int player2Score = 0;
	public int player3Score = 0;
	public int player4Score = 0;
	int roundNum = 1;

	public bool firstDeath = false;
	bool secondDeath = false;
	bool thirdDeath = false;
	bool winner;

    public bool inLevel = true;

	bool player1Alive = true;
	bool player2Alive = true;
	bool player3Alive = true;
	bool player4Alive = true;

	public float p1riceSpeed = 200f;
	public float p2riceSpeed = 200f;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this); 
	}
	
	// Update is called once per frame
	void Update () {
        if (inLevel)
        {
            GameObject player1 = GameObject.Find("Player1");
            GameObject player2 = GameObject.Find("Player2");
            GameObject player3 = GameObject.Find("Player3");
            GameObject player4 = GameObject.Find("Player4");

            //Player1 Checks
            if (player1 == null)
            {
                if (player1Alive)
                {

                    if ((firstDeath) && (secondDeath) && (!thirdDeath))
                    {
                        player1Score += 7;
                        thirdDeath = true;
                        player1Alive = false;
                    }

                    if ((firstDeath) && (!secondDeath))
                    {
                        player1Score += 5;
                        secondDeath = true;
                        player1Alive = false;
                    }

                    if (!firstDeath)
                    {
                        player1Score += 3;
                        firstDeath = true;
                        player1Alive = false;
                    }
                }
            }

            //Player2 Checks
            if (player2 == null)
            {
                if (player2Alive)
                {

                    if ((firstDeath) && (secondDeath) && (!thirdDeath))
                    {
                        player2Score += 7;
                        thirdDeath = true;
                        player2Alive = false;
                    }

                    if ((firstDeath) && (!secondDeath))
                    {
                        player2Score += 5;
                        secondDeath = true;
                        player2Alive = false;
                    }

                    if (!firstDeath)
                    {
                        player2Score += 3;
                        firstDeath = true;
                        player2Alive = false;
                    }
                }
            }

            //Player3 Checks
            if (player3 == null)
            {
                if (player3Alive)
                {

                    if ((firstDeath) && (secondDeath) && (!thirdDeath))
                    {
                        player3Score += 7;
                        thirdDeath = true;
                        player3Alive = false;
                    }

                    if ((firstDeath) && (!secondDeath))
                    {
                        player3Score += 5;
                        secondDeath = true;
                        player3Alive = false;
                    }

                    if (!firstDeath)
                    {
                        player3Score += 3;
                        firstDeath = true;
                        player3Alive = false;
                    }
                }
            }

            //Player4 Checks
            if (player4 == null)
            {
                if (player4Alive)
                {

                    if ((firstDeath) && (secondDeath) && (!thirdDeath))
                    {
                        player4Score += 7;
                        thirdDeath = true;
                        player4Alive = false;
                    }

                    if ((firstDeath) && (!secondDeath))
                    {
                        player4Score += 5;
                        secondDeath = true;
                        player4Alive = false;
                    }

                    if (!firstDeath)
                    {
                        player4Score += 3;
                        firstDeath = true;
                        player4Alive = false;
                    }
                }
            }

            if ((firstDeath) && (secondDeath) && (thirdDeath) && (!winner))
            {
                if (player1Alive)
                {
                    player1Score += 10;
                    winner = true;
                }
                if (player2Alive)
                {
                    player2Score += 10;
                    winner = true;
                }
                if (player3Alive)
                {
                    player3Score += 10;
                    winner = true;
                }
                if (player4Alive)
                {
                    player4Score += 10;
                    winner = true;
                }
                StartCoroutine(NextRound());
            }
        }
	}

	IEnumerator NextRound(){
		//Show score or winner or suhin here
		yield return new WaitForSeconds(3);
		firstDeath = false;
		secondDeath = false;
		thirdDeath = false;
		winner = false;
		player1Alive = true;
		player2Alive = true;
		player3Alive = true;
		player4Alive = true;
		if (roundNum != 5)
		{
			roundNum++;
			Application.LoadLevel ("ScoreboardScene");
		}
		if(roundNum == 5)
		{
			roundNum = 0;
			Application.LoadLevel ("EndScene");
		}
		inLevel = false;
	}
}
