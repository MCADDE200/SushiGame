using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {


	bool onGround;
	public bool onWall;
	public bool jump = false;
	public bool wallJump = true;
    bool facingRight = true;
	bool canKillP2 = false;
	bool canKillP3 = false;
	bool canKillP4 = false;
	public bool riceThrow;
	public bool p1Throw;

	public Rigidbody2D rigidBody2D;

	public Transform groundCheck;
	public Transform wallCheck;

	public bool stuck;
	public bool player1Attacking;

	public GameObject riceSpawn;
	public GameObject throwingRice;
	//public GameObject projectileLeft;
    
    public float horizontal = 0f;

	Animator anim;


	void Awake () {
		//rigidBody2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();  
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxisRaw("Horizontal");

		if (stuck) {
			StartCoroutine (UnStick ());
		}


        //Checks to see if the player is on the ground or against the wall
		onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		onWall = Physics2D.Linecast(transform.position, wallCheck.position, 1 << LayerMask.NameToLayer ("Wall"));

		GameObject gameData = GameObject.Find ("GameData");
		if (gameData != null) {
			GameDataScript gameDataScript = gameData.GetComponent<GameDataScript> ();
			if (!facingRight) {
				gameDataScript.p1riceSpeed = -200f;
			}
			if (facingRight) {
				gameDataScript.p1riceSpeed = 200f;
			}
		}

		if (Input.GetButtonDown ("Jump"))
			{
			if ((onGround) && (jump == false)) {
				wallJump = true;
				jump = true;
				anim.SetBool("Jump", true);
				StartCoroutine (Jump ());
			}
			if (((onWall) && (!jump) && (wallJump)))
			{
				anim.SetBool("Jump", false);
				anim.SetBool("Jump", true);
				StartCoroutine (Jump ());
				jump = true;
				wallJump = false;
			}
		}

		if (Input.GetButtonDown("Fire1"))
		{
			anim.SetBool ("Attack", true);
			StartCoroutine (Attack ());
			GameObject player2 = GameObject.Find ("Player2");
			if (player2 != null) {
				Player2Script player2Script = player2.GetComponent<Player2Script> ();
				if ((canKillP2) && (player2Script.player2Attacking == false)) {
					Destroy (GameObject.Find ("Player2"));
					canKillP2 = false;
				}
				if ((canKillP2) && (player2Script.player2Attacking == true)) {
					if (facingRight) {
						player2.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (200f, 0.0f));
						rigidBody2D.AddForce (new Vector2 (-200f, 0.0f));
					}
					if (!facingRight) {
						player2.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-200f, 0.0f));
						rigidBody2D.AddForce (new Vector2 (200f, 0.0f));
					}

				}
			}

			if (canKillP3) {
				Destroy (GameObject.Find("Player3"));
				canKillP3 = false;
			}

			if (canKillP4) {
				Destroy (GameObject.Find("Player4"));
				canKillP4 = false;
			}
		}

		if (Input.GetButtonDown ("Secondary1")) {
			if (riceThrow) {
				p1Throw = true;
				StartCoroutine (Rice ());
				riceThrow = false;
			}
		}

	}

	void FixedUpdate() {
		int jumpPower = 300;
		float maxSpeed = 4f;
		float moveForce = 25f;

		if (horizontal != 0f && anim.GetBool("Jump") == false) {
			anim.SetBool ("Moving", true);
		} else {
			anim.SetBool ("Moving", false);
		}

        //Handles the player movement
		if (jump == true && (!stuck)) {
			moveForce = 2f;
		} else {
			moveForce = 10f;
		}

		if ((horizontal * rigidBody2D.velocity.x) < maxSpeed && (!stuck))
			rigidBody2D.AddForce(Vector3.right * horizontal * moveForce);

		if (Mathf.Abs (rigidBody2D.velocity.x) > maxSpeed && (!stuck))
			rigidBody2D.velocity = new Vector3(Mathf.Sign (rigidBody2D.velocity.x) * maxSpeed, rigidBody2D.velocity.y, 0.0f);



        if (horizontal > 0 && !facingRight)
            Flip();
        else if (horizontal < 0 && facingRight)
            Flip();


		if (jump == true) {
			rigidBody2D.AddForce (new Vector3 (0.0f, jumpPower, 0.0f));
			jump = false;
		}


	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name.Equals("Player2"))
		{
			canKillP2 = true;
		}

		if(other.gameObject.name.Equals("Player3"))
		{
			canKillP3 = true;
		}

		if(other.gameObject.name.Equals("Player4"))
		{
			canKillP4 = true;
		}

		if (other.gameObject.name.Equals ("Rice(Clone)")) {
			riceThrow = true;
			Destroy (GameObject.Find ("Rice(Clone)"));
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.name.Equals("Player2"))
		{
			canKillP2 = false;
		}

		if(other.gameObject.name.Equals("Player3"))
		{
			canKillP3 = false;
		}

		if(other.gameObject.name.Equals("Player4"))
		{
			canKillP4 = false;
		}
	}

	IEnumerator Attack()
	{
		player1Attacking = true;
		yield return new WaitForSeconds (0.3f);
		anim.SetBool ("Attack", false);
		player1Attacking = false;
	}

	IEnumerator Jump()
	{
		yield return new WaitForSeconds (0.3f);
		anim.SetBool ("Jump", false);
	}

	IEnumerator Rice() {
		//if (facingRight) {
			GameObject Rice = (GameObject)Instantiate (throwingRice);
			Rice.transform.position = riceSpawn.transform.position;
			Rice.name = "Sticky Rice";
			yield return new WaitForSeconds (0.5f);
		 /*else {
			GameObject Projectile = (GameObject)Instantiate (projectileLeft);
			Projectile.transform.position = projectileSpawn.transform.position;
			Projectile.name = "bullet";
		}
		yield return new WaitForSeconds (0.5f);
		//anim.SetBool ("Throw", false);*/
	}

	IEnumerator UnStick()
	{
		yield return new WaitForSeconds (5f);
		stuck = false;
	}
}

