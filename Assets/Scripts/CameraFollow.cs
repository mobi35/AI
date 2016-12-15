using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	[SerializeField]
	private float xMax;
	[SerializeField]
	private float xMin;
	[SerializeField]
	private float yMin;
	[SerializeField]
	private float yMax;

	public Transform target;
	public Transform target2;
	public Transform target3;
	public Transform target4;
	public Transform target5;
	public Transform target6;
	public Transform target7;
	// Use this for initialization
	void Start () 
	{
		
		if (GameObject.Find ("BoxerPlayer")) {
			target = GameObject.Find ("BoxerPlayer").transform;
		}

		if (GameObject.Find ("PlayerPoison")) {
			target = GameObject.Find ("PlayerPoison").transform;
		}


		if (GameObject.Find ("PlayerMedusa")) {
			target = GameObject.Find ("PlayerMedusa").transform;
		}

		if (GameObject.Find ("PlayerSword")) {
			target = GameObject.Find ("PlayerSword").transform;
		}



		if (GameObject.Find ("PlayerLion")) {
			target = GameObject.Find ("PlayerLion").transform;
		}

		if (GameObject.Find ("FirePlayer")) {
			target = GameObject.Find ("FirePlayer").transform;
		}	
		if (GameObject.Find ("PlayerFire")) {
			target = GameObject.Find ("PlayerFire").transform;
		}
	



	}
	
	// Update is called once per frame
	void LateUpdate ()
	{

		transform.position = new Vector3 (Mathf.Clamp(target.position.x,xMin,xMax),Mathf.Clamp(target.position.y,yMin,yMax),transform.position.z);
	}
}
