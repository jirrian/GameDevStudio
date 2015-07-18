using UnityEngine;
using System.Collections;

public class TriggerCube : MonoBehaviour {
	bool triggered = false;

	// called once trigger is entered
	void OnTriggerEnter(){
		triggered = true;
	}

	// Update is called once per frame
	void Update () {
		if (triggered == true){
			Debug.Log("true");
			transform.Rotate(0f, 10f, 0f);
		}
	}
}
