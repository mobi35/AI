using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract class Character : MonoBehaviour {

	public Animator AN { get; private set; }
	[SerializeField]
	protected float moveSpeed;

	protected bool facingRight;

	[SerializeField]
	private GameObject wave;
	[SerializeField]
	protected int health = 100;
	[SerializeField]
	private EdgeCollider2D SwordCollider;
	[SerializeField]
	private List<string> damageSources;


	public abstract bool isDead { get;}
	public bool Attack { get; set;}

	public bool TakingDamage {get;set;}
	// Use this for initialization
	public virtual void Start () {


		AN = GetComponent<Animator> ();
		
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeDirection()
	{
		facingRight = !facingRight;
		transform.localScale = new Vector3 (-transform.localScale.x * 1, 5, 1);


	}

	public virtual void ThrowWave(int value)
	{
		if (facingRight) 
		{
			
			//			StartCoroutine(WaitAndPrint(1.5F));
			GameObject tmp =  (GameObject)Instantiate (wave, transform.position, Quaternion.identity);
			tmp.GetComponent<Particlewave>().Initialize(Vector2.right);
			
		}
		else 
		{
			//			 StartCoroutine(WaitAndPrint(1.5F));
			GameObject tmp =  (GameObject)Instantiate (wave, transform.position, Quaternion.Euler(new Vector3(0,0,-180)));
			tmp.GetComponent<Particlewave>().Initialize(-Vector2.right);
			
		}

	}

	public void MeleeAttack()

	{
			SwordCollider.enabled = !SwordCollider.enabled;
	}


	public abstract IEnumerator TakeDamage();

	public virtual void OnTriggerEnter2D(Collider2D other) 
	{
		if (damageSources.Contains(other.tag))
		{
			StartCoroutine(TakeDamage());
		}

	}
	
}
