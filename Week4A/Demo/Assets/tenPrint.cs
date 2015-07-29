using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tenPrint : MonoBehaviour {
	public Text myText; // assign in inspector

	// Use this for initialization
	void Start () {
		//set random seed
		Random.seed = 1;

		int count = 0;
		while(count < 2000){
			// pick either \ or /
			myText.text += Random.Range(0f,100f) > 50f ? "/" : "\\";
			count++;
			Debug.Log(count.ToString());
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
		// RELOAD level
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
