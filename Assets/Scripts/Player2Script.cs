using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player2Script : MonoBehaviour {


	public bool onGround;
	public bool onRWall;
	public bool onLWall;
	bool jump = false;
	public bool wallJump = true;

	public Rigidbody2D rigidBody2D;

	public Transform groundCheck;
	public Transform wallCheckR;
	public Transform wallCheckL;

	public float horizontal = 0f;

	//Events
	public delegate void checkAttack();

	public event checkAttack onCheckAttack;

	//public LayerMask ground;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxisRaw("Horizontal2");
		//
		//		
		//		if (horizontal > 0f) {
		//			transform.Translate (0.05f, 0, 0);
		//		}else if (horizontal < 0f){
		//			transform.Translate (-0.05f, 0, 0);
		//		}
		//
		//		if(Input.GetButtonDown("Jump"))
		//		{
		//			StartCoroutine(LerpPosition(transform.position, transform.position + new Vector3(0, 1, 0)));
		//			//transform.Translate (0, 1, 0);
		//		}

		//Checks to see if the player is on the ground or against the wall
		onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		onRWall = Physics2D.Linecast(transform.position, wallCheckR.position, 1 << LayerMask.NameToLayer ("Wall"));
		onLWall = Physics2D.Linecast(transform.position, wallCheckL.position, 1 << LayerMask.NameToLayer ("Wall"));
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
		//
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



		//		if (horizontal > 0 && !facingRight)
		//			Flip ();
		//		else if (horizontal < 0 && facingRight)
		//			Flip ();

		//This will handle the jump
		if (onGround)
		{
			wallJump = false;
		}

		if (Input.GetButtonDown ("Jump2")) {
			if ((onGround) && (jump == false)) {
				jump = true;
				wallJump = true;
			}
			if (((onLWall) && (!jump) && (wallJump)) || ((onRWall) && (!jump) && (wallJump)))
			{
				jump = true;
				wallJump = false;
			}
		}

		if (jump == true) {
			rigidBody2D.AddForce (new Vector3 (0.0f, jumpPower, 0.0f));
			jump = false;
		}

		if (Input.GetButtonDown("Fire2"))
		{
			onCheckAttack ();
		}
	}

	//	void Flip() {
	//		facingRight = !facingRight;
	//		Vector3 theScale = transform.localScale;
	//		theScale.x *= -1;
	//		transform.localScale = theScale;
	//	}
	//
	IEnumerator LerpPosition(Vector3 start, Vector3 end)
	{
		float currentTime = 0;
		float totalTime = 0.2f;
		while (currentTime < totalTime) {
			currentTime += Time.deltaTime;
			transform.position = Vector3.Lerp(start, end, currentTime/totalTime);
			yield return 0;
		}
	}
}
