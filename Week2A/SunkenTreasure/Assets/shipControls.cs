using UnityEngine;
using System.Collections;

public class shipControls : MonoBehaviour {
	float defaultSpeed = 3.5f;
	public float speed;

	// Use this for initialization
	void Start(){
			speed = defaultSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(KeyCode.W)){
			transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * speed;
		}
		if(Input.GetKey(KeyCode.A)){
			transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * -speed;
		}
		if(Input.GetKey(KeyCode.S)){
			transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * -speed;
		}
		if(Input.GetKey(KeyCode.D)){
			transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * speed;
		}
		if(Input.GetKeyDown(KeyCode.LeftShift)){
			speed = speed * 2;
		}
		if(Input.GetKeyUp(KeyCode.LeftShift)){
			speed = defaultSpeed;
		}
	}
}
