using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player4Script : MonoBehaviour {


	bool onGround;
	public bool onWall;
	public bool jump = false;
	public bool wallJump = true;
	bool facingRight = true;
	bool canKillP1 = false;
	bool canKillP3 = false;
	bool canKillP2 = false;

	public Rigidbody2D rigidBody2D;

	public Transform groundCheck;
	public Transform wallCheck;

	public float horizontal = 0f;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxisRaw("Horizontal4");


		//Checks to see if the player is on the ground or against the wall
		onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		onWall = Physics2D.Linecast(transform.position, wallCheck.position, 1 << LayerMask.NameToLayer ("Wall"));

		if (Input.GetButtonDown ("Jump4")) {
			if ((onGround) && (jump == false)) {
				wallJump = true;
				jump = true;
			}
			if (((onWall) && (!jump) && (wallJump)))
			{
				jump = true;
				wallJump = false;
			}
		}
		if (Input.GetButtonDown("Fire4"))
		{
			if (canKillP1) {
				Destroy (GameObject.Find("Player1"));
				canKillP1 = false;
			}

			if (canKillP3) {
				Destroy (GameObject.Find("Player3"));
				canKillP3 = false;
			}

			if (canKillP2) {
				Destroy (GameObject.Find("Player2"));
				canKillP2 = false;
			}
		}

	}

	void FixedUpdate() {
		int jumpPower = 250;
		float maxSpeed = 2f;
		float moveForce = 20f;

		//		if (horizontal != 0f && anim.GetBool("Jump") == false) {
		//			anim.SetBool ("Walking", true);
		//		} else {
		//			anim.SetBool ("Walking", false);
		//		}

		//Handles the player movement
		if (jump == true) {
			moveForce = 2f;
		} else {
			moveForce = 10f;
		}

		if ((horizontal * rigidBody2D.velocity.x) < maxSpeed)
			rigidBody2D.AddForce(Vector3.right * horizontal * moveForce);

		if (Mathf.Abs (rigidBody2D.velocity.x) > maxSpeed)
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
		if(other.gameObject.name.Equals("Player1"))
		{
			canKillP1 = true;
		}

		if(other.gameObject.name.Equals("Player3"))
		{
			canKillP3 = true;
		}

		if(other.gameObject.name.Equals("Player2"))
		{
			canKillP2 = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.name.Equals("Player1"))
		{
			canKillP1 = false;
		}

		if(other.gameObject.name.Equals("Player3"))
		{
			canKillP3 = false;
		}

		if(other.gameObject.name.Equals("Player2"))
		{
			canKillP2 = false;
		}
	}
}