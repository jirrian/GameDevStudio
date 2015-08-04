using UnityEngine;
using System.Collections;

public class npc : MonoBehaviour {
	public Vector3 destination;
	public float speed = 100f;

	bool grounded = false;

	// Use this for initialization
	void Start () {
		// call function every 10 seconds
		InvokeRepeating("PickDest", 1f, 3f);
	
	}
	
	void Update(){
		// do grounded check
		Ray ray = new Ray(transform.position, new Vector3(0,-1,0));
		if(Physics.Raycast(ray, 1.1f)){
			grounded = true;
		}else{
			grounded = false;
		}

		Debug.Log("grounded " + grounded);
	}

	// Update is called once per physics frame
	void FixedUpdate () {

		// move to destination
		Vector3 moveDirection = destination - transform.position;
		moveDirection = Vector3.Normalize(moveDirection);	// normalize vector

		// raycast downward in front
		Ray ray = new Ray(transform.position + moveDirection, new Vector3(0,-1,0));
		bool groundInFront = Physics.Raycast(ray, 1.1f);

		if(Vector3.Distance(transform.position, destination) > 1f && grounded && groundInFront){
			GetComponent<Rigidbody>().AddForce(moveDirection * speed);
		}

	}

	void PickDest(){
		destination = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
	}

	// visualize path for debug
	void OnDrawGizmos(){
		Gizmos.DrawLine(transform.position, destination);
		Gizmos.DrawWireSphere(destination, 0.5f);
	}
}
