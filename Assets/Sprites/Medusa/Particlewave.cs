using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class Particlewave : MonoBehaviour {
	[SerializeField]
	private float speed;

	private Rigidbody2D myRB;

	private Vector2 direction;
	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();

	}

	void FixedUpdate()
	{
		myRB.velocity = direction * speed;
	}

	public void Initialize(Vector2 direction)
	{
		this.direction = direction;
	}
	// Update is called once per frame


	void OnBecameInvisible() {
		Destroy (gameObject);
	}



}
