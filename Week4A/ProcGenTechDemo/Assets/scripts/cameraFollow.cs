using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {
	public Transform target;	// object being followed
	public float distance;	// distance between camera and object

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// change camera position to follow target object
		transform.position = new Vector3(target.transform.position.x, target.transform.position.y + distance, target.transform.position.z);
	}
}
