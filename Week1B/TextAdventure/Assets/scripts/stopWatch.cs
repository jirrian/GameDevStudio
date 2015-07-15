using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class stopWatch : MonoBehaviour {

	public Text myTextObject;
	float timeElapsed = 0f;	// cast as float

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// progress time if spacebar pushed
		if(Input.GetKey (KeyCode.Space)){ 
			timeElapsed += Time.deltaTime;
		} 

		// display current time elapsed
		myTextObject.text = "Try to land on 10 " + timeElapsed.ToString ();
	}
}
