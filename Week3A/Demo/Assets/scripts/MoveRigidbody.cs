using UnityEngine;
using System.Collections;

public class MoveRigidbody : MonoBehaviour {

	public float speed = 5f;
	public float turnSpeed = 90f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		Rigidbody rbody = GetComponent<Rigidbody>();

		//rotating
		//rbody.AddRelativeForce(0f, 0f, y * speed * Time.deltaTime);

		//transform.Rotate(0f, x * turnSpeed * Time.deltaTime, 0f);

		//side stepping
		rbody.AddRelativeForce(x * speed * Time.deltaTime, 0f, y * speed * Time.deltaTime);
	}
}
