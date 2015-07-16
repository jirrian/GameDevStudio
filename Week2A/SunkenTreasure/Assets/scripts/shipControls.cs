using UnityEngine;
using System.Collections;

public class shipControls : MonoBehaviour {
	float defaultSpeed;
	public float speed;
	Vector3 forward;
	// Use this for initialization
	void Start(){
		defaultSpeed = 9f;
		forward = transform.forward * -1;

		speed = defaultSpeed;
		transform.forward = forward;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(KeyCode.W)){	// north
			transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * speed;
			transform.forward = forward;	// change orientation
		}
		else if(Input.GetKey(KeyCode.A)){	// west
			transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * -speed;
			transform.forward = forward + new Vector3(90f, 0f, 0f);	// change orientation	
		}
		else if(Input.GetKey(KeyCode.S)){	// south
			transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * -speed;
			transform.forward = (forward * -1); // change orientation
		}
		else if(Input.GetKey(KeyCode.D)){	// east
			transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * speed;
			transform.forward = forward + new Vector3(-90f, 0f, 0f); // change orientation
		}

		// speed up
		if(Input.GetKeyDown(KeyCode.LeftShift)){
			speed = speed * 2;
		}
		if(Input.GetKeyUp(KeyCode.LeftShift)){
			speed = defaultSpeed;
		}
	}
}
