using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {
	bool started;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0f;
		started = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
			started = true;

		if (started == true){
			GetComponent<TextMesh>().text = "";
			Time.timeScale = 1f;
		}
	}
}
