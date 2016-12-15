using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Enemy : Character
{
	public Vector2 jumpVector;
	public float count;
   public Text win;

	public bool jump;
	public Slider slide;
	public Text life;
	private IEnemyState currentState;


	public GameObject Target {
		get;
		set;
	}




	[SerializeField]
	private float meleeRange;
	[SerializeField]
	private float throwRange;
	public bool InMeleeRange{

		get{
			if(Target != null)
			{
				return Vector2.Distance(transform.position, Target.transform.position) <= meleeRange;
			}
			return false;
		}

	}

	public bool InThrowRange{	
		
		get{
			if(Target != null)
			{
				return Vector2.Distance(transform.position, Target.transform.position) <= throwRange;
			}
			return false;
		}

	}

	public override void Start() 
	{
		
		base.Start ();
		ChangeState (new IdleState ());
	
		jump = true;
	}




	void Update()
	{
        if (Application.loadedLevelName == "Adventure1" && health == 0)
        {
            StartCoroutine("love1");
          
        }

        if (Application.loadedLevelName == "Adventure2" && health == 0)
        {
            StartCoroutine("love2");
        }


        if (Application.loadedLevelName == "Adventure3" && health == 0)
        {
            StartCoroutine("love3");
        }


        if (Application.loadedLevelName == "Adventure4" && health == 0)
        {

            StartCoroutine("love4");
        }

        if (Application.loadedLevelName == "Adventure5" && health == 0)
        {
            StartCoroutine("love5");
        }


        

		count += Time.deltaTime;
	//	if (Input.GetKeyDown (KeyCode.E)) 
	//	{
			
		if (count >= 3) 
		{
			jump = true;
		}
	
	//	}

		slide.value = health;
		if (!isDead) 
		{

			if(!TakingDamage){
				currentState.Execute();

			
			}
			LookAtTarget();
		}

		SetLife ();
	


	}

    


	private void LookAtTarget()

	{
		if (Target != null) 
		{
			float xDir = Target.transform.position.x - transform.position.x;

			if(xDir < 0 && facingRight || xDir > 0 && !facingRight)
			{
				ChangeDirection();
			}
		}
	}
	public void ChangeState(IEnemyState newState)
	{
		if (currentState != null) 
		{
			currentState.Exit ();
		}
		currentState = newState;

		currentState.Enter(this);
	}

	public void Move() 
	{
		
	
			//transform.Translate(Vector2.right * (moveSpeed * Time.deltaTime));
		
		if (!Attack && health >= 60) {
			AN.SetFloat ("speed", 1);
			//transform.Translate (GetDirection () * moveSpeed * Time.deltaTime);
			transform.Translate(Vector2.right * (moveSpeed * Time.deltaTime));

		}


		if (!Attack && health <= 50) 
		{
			AN.SetFloat ("speed", 1);
			transform.Translate(-Vector2.right * (moveSpeed * Time.deltaTime));
		}








	
	}


	


	public Vector2 GetDirection()
	{
		return facingRight ? -Vector2.right : Vector2.right;
	}

	public override void OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D (other);
		currentState.OnTriggerEnter (other);
		if (other.gameObject.tag == "Wave" && jump == true) 
		{	
			
			GetComponent<Rigidbody2D> ().AddForce (jumpVector, ForceMode2D.Force);
			count = 0;
			jump = false;
		}

	}


	#region implemented abstract members of Character
	public override IEnumerator TakeDamage ()
	{
		health -= 10;
		if (!isDead) {
			AN.SetTrigger ("damage");


		} else 
		{
			AN.SetTrigger("death");
			StartCoroutine(death());

		}
		yield return null;
	}
	#endregion

	#region implemented abstract members of Character

	public override bool isDead {
		get {
			return health <= 0;

		}
	}

	#endregion

	IEnumerator death() 
	{

		yield return new WaitForSeconds (7f);
		Application.LoadLevel("PLAYERWIN");
	}

	void SetLife() 
	{
		life.text = "AI Health" + health;
	}



    IEnumerator love1()
    {
        yield return new WaitForSeconds(3);
        win.text = "You win";
        yield return new WaitForSeconds(3);
        Application.LoadLevel("Adventure2");
    }

    IEnumerator love2()
    {
        yield return new WaitForSeconds(3);
        win.text = "You win";
        yield return new WaitForSeconds(3);
        Application.LoadLevel("Adventure3");
    }


    IEnumerator love3()
    {
        yield return new WaitForSeconds(3);
        win.text = "You win";
        yield return new WaitForSeconds(3);
        Application.LoadLevel("Adventure4");
    }


    IEnumerator love4()
    {
        yield return new WaitForSeconds(3);
        win.text = "You win";
        yield return new WaitForSeconds(3);
        Application.LoadLevel("Adventure5");
    }


    IEnumerator love5()
    {
        yield return new WaitForSeconds(3);
        win.text = "You are the Champion";
        yield return new WaitForSeconds(3);
        Application.LoadLevel("Mainmenu");
    }

}
