using UnityEngine;
using System.Collections;

public class PowerUpsSpawnScript : MonoBehaviour {

    public GameObject rice;
    public GameObject other;

	// Use this for initialization
	void Start () {
        //StartCoroutine(SpawnPowerUps());
        InvokeRepeating("SpawnPowerUps", 10f, 10f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnPowerUps()
    {
        GameObject pos1 = GameObject.Find("PowerUp Location 1");
        GameObject pos2 = GameObject.Find("PowerUp Location 2");
        GameObject pos3 = GameObject.Find("PowerUp Location 3");
		GameObject prev = GameObject.Find ("Rice(Clone)");

		if(prev != null)
		{
			Destroy (prev);
		}

//        int powerupChoice = Random.Range(0, 2);
        int spawnLocation = Random.Range(0, 3);

        //if (powerupChoice == 0)
      //  {
            switch(spawnLocation)
            {
                case 0:
                    Instantiate(rice, pos1.transform.position, transform.rotation);
                    break;
                case 1:
                    Instantiate(rice, pos2.transform.position, transform.rotation);
                    break;
                case 2:
                    Instantiate(rice, pos3.transform.position, transform.rotation);
                    break;
                default:
                    break;
            }
       // }

//        if (powerupChoice == 1)
//        {
//            switch (spawnLocation)
//            {
//                case 0:
//                    Instantiate(other, pos1.transform.position, transform.rotation);
//                    break;
//                case 1:
//                    Instantiate(other, pos2.transform.position, transform.rotation);
//                    break;
//                case 2:
//                    Instantiate(other, pos3.transform.position, transform.rotation);
//                    break;
//                default:
//                    break;
//            }
//        }
    }
}
