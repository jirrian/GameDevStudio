using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UItext : MonoBehaviour {
	public GameObject treasure;
	string text;

	// Use this for initialization
	void Start () {
		text = "";
	}
	
	// Update is called once per frame
	void Update () {
		text = "";

		if(treasure.GetComponent<gameLogic>().win == true){	// win the game
			text = "You won!";
		}
		// hints
		else if(treasure.GetComponent<gameLogic>().dist > 250f){
			text = "Very far away";
		}
		else if(treasure.GetComponent<gameLogic>().dist < 50f){
			text = "Getting close";
		}

		// direction traveling in
		if(treasure.GetComponent<gameLogic>().win == false){
			if(Input.GetKey(KeyCode.W)){
				text += "\nNorth";
			}else if (Input.GetKey(KeyCode.A)){
				text += "\nWest";
			}else if (Input.GetKey(KeyCode.D)){
				text += "\nEast";
			}else if (Input.GetKey(KeyCode.S)){
				text += "\nSouth";
			}
		}

		GetComponent<Text>().text = text;
	}
}
