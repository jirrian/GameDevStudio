using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {
	bool started;

	// Use this for initialization
	void Start () {
		started = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
			started = true;

		if (started == true)
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
	}
}
