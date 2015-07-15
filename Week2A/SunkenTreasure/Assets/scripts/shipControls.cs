using UnityEngine;
using System.Collections;

public class shipControls : MonoBehaviour {
	float defaultSpeed;
	public float speed;
	Vector3 forward;
	// Use this for initialization
	void Start(){
		defaultSpeed = 3.5f;
		forward = transform.forward * -1;

		speed = defaultSpeed;
		transform.forward = forward;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(KeyCode.W)){
			transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * speed;
			transform.forward = forward;
		}
		else if(Input.GetKey(KeyCode.A)){
			transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * -speed;
			transform.forward = forward + new Vector3(90f, 0f, 0f);		
		}
		else if(Input.GetKey(KeyCode.S)){
			transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * -speed;
			transform.forward = (forward * -1);
		}
		else if(Input.GetKey(KeyCode.D)){
			transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * speed;
			transform.forward = forward + new Vector3(-90f, 0f, 0f);
		}
		if(Input.GetKeyDown(KeyCode.LeftShift)){
			speed = speed * 3;
		}
		if(Input.GetKeyUp(KeyCode.LeftShift)){
			speed = defaultSpeed;
		}
	}
}
