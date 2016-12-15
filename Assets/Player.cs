using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Player : Character {
	public Text life;
	public Slider slide;
    public Text lose;
	private static Player instance;

	public static Player Instance {
		get {

			if(instance == null)
			{
				instance = GameObject.FindObjectOfType<Player>();

			}

			return instance;
		}

	}




	[SerializeField]

	private Transform[] groundPoints;




	[SerializeField]

	private float groundRadius;
	[SerializeField]
	private LayerMask whatIsGround;

	private bool isGrounded;

	[SerializeField]

	private float jumpForce;


	[SerializeField]
	private bool airControl;
	public Rigidbody2D RB { get; set;}





	public bool Jump { get; set;}

	public bool OnGround { get; set;}

	private Vector2 startPos;
	// Use this for initialization

      
	public override void Start () {
		base.Start ();
		startPos = transform.position;
		RB = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Application.loadedLevelName == "Adventure1" && health == 0)
        {

            StartCoroutine("lose1");
        }

        if (Application.loadedLevelName == "Adventure2" && health == 0)
        {

            StartCoroutine("lose2");
        }

        if (Application.loadedLevelName == "Adventure3" && health == 0)
        {

            StartCoroutine("lose1");
        }

        if (Application.loadedLevelName == "Adventure4" && health == 0)
        {


            StartCoroutine("lose1");
        }

        if (Application.loadedLevelName == "Adventure5" && health == 0)
        {

            StartCoroutine("lose1");
        }



		OnGround = IsGrounded ();

		float horizontal = Input.GetAxis("Horizontal");
		Movement (horizontal);
		Flip (horizontal);

		SetLife ();
		HandleLayers ();

	}




	void Update () 
	{
		AttackInput ();
		slide.value = health;

	}
	public void Movement (float horizontal) 
	{
		if(RB.velocity.y < 0)
		{
			AN.SetBool("land",true);

		}
		if(!Attack && (OnGround || airControl) )
		{
			RB.velocity = new Vector2(horizontal * moveSpeed,RB.velocity.y);

		}
		if(Jump && RB.velocity.y == 0)
		{
			RB.AddForce(new Vector2(0,jumpForce));
		}
		AN.SetFloat("speed",Mathf.Abs (horizontal));
	
	}


	private void AttackInput() 
	{
		if (Input.GetKeyDown (KeyCode.Z)) 
		{
			AN.SetTrigger("attack");
		}
		if (Input.GetKeyDown (KeyCode.Space))
		{
			AN.SetTrigger("jump");
		}

		if (Input.GetKeyDown (KeyCode.X) && OnGround )
		{
			AN.SetTrigger("wave");


		}
	}



	private void Flip(float horizontal) 
	{
	//	if (RB.velocity.y < 0)
	//	{
	//		AN.SetBool("land",true);
	//	}
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) 
		{
			ChangeDirection();
		}
	}


	private bool IsGrounded() 
	{
		if (RB.velocity.y <= 0) 
		{
			foreach (Transform point in groundPoints)
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position,groundRadius,whatIsGround);
					for(int i = 0; i < colliders.Length; i++)
				{
					if(colliders[i].gameObject != gameObject)
					{
					
						return true;
					}
				}
			}

		}
		return false;
	}

	private void HandleLayers()
	{
		if (!OnGround) {
			AN.SetLayerWeight (1, 1);

		} else
		{
			AN.SetLayerWeight(1,0);
		}
	}


	public override void ThrowWave(int value)
		
	{
		if (!OnGround && value == 1 || OnGround && value == 0) 
		{
			base.ThrowWave(value);
		}

	}







//
//	IEnumerator WaitAndPrint(float waitTime) {
//		yield return new WaitForSeconds(waitTime);
//		Instantiate (wave, transform.position, Quaternion.identity);
//	}
//
	

	#region implemented abstract members of Character
	public override IEnumerator TakeDamage ()
	{

	
		health -= 10;

		if (!isDead) 
		{
			AN.SetTrigger("damage");
		} else 
		{
			AN.SetLayerWeight(1,0);
			AN.SetTrigger("death");
			StartCoroutine(death());
		}
		yield return null;

	}
	#endregion

	#region implemented abstract members of Character

	public override bool isDead {
		get {
			return health <=0;
		}
	}

	#endregion

	IEnumerator death() 
	{
		
		yield return new WaitForSeconds (7f);
		Application.LoadLevel("ENEMY WIN");
	}

    IEnumerator lose5()
    {
        lose.text = "You Lose";
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("Mainmenu");
    }


    IEnumerator lose1()
    {
        lose.text = "You Lose";
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("Mainmenu");
    }


    IEnumerator lose2()
    {
        lose.text = "You Lose";
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("Mainmenu");
    }


    IEnumerator lose3()
    {
        lose.text = "You Lose";
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("Mainmenu");
    }


    IEnumerator lose4()
    {
        lose.text = "You Lose";
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("Mainmenu");
    }

	void SetLife() 
	{
		life.text = "Player Health" + health;
	}
}
