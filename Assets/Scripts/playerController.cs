using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {


	//jump variable


	bool isGround = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	public float maxSpeed;

	Rigidbody2D RB;
	Animator AN;
	bool facingRight;
	// Use this for initialization
	void Start () {
		RB = GetComponent<Rigidbody2D> ();
		AN = GetComponent<Animator> ();
		facingRight = true;


	}
	
	// Update is called once per frame
	void FixedUpdate () {


		isGround = Physics2D.OverlapCircle (groundCheck.position,groundRadius,whatIsGround);
		AN.SetBool ("grounded",isGround);
		AN.SetFloat ("vSpeed", RB.velocity.y);



		float punch = Input.GetAxis("Vertical");

		float move = Input.GetAxis ("Horizontal");
		RB.velocity = new Vector2 (move * maxSpeed, RB.velocity.y);

		AN.SetFloat ("speed", Mathf.Abs (move));

		AN.SetFloat ("punch", Mathf.Abs (punch));



		if (move > 0 && ! facingRight) {
			flip();
		}else if (move < 0 && facingRight){
			flip();
	}

	}


	void Update() 
	{
		if (isGround && Input.GetKeyDown (KeyCode.Space)) 
		{
			AN.SetBool("grounded",false);
			RB.AddForce(new Vector2(0, jumpForce));

		}
	}
		void flip (){
			facingRight =! facingRight;
			Vector3 scaled = transform.localScale;
		scaled.x *= -1;
		transform.localScale = scaled;

		
}
}