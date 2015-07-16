using UnityEngine;
using System.Collections;

public class gameLogic : MonoBehaviour {
	public GameObject player;

	public bool win;	// if player won game
	public float dist;	// distance between 'treasure' and player

	// Use this for initialization
	void Start () {
		win = false;
	}
	
	// Update is called once per frame
	void Update () {
		dist = Vector3.Distance(player.transform.position, this.transform.position);
		
		// sets win to true if player is within distance
		if(dist <= 15f){
			win = true;
		}
		else{
			win = false;
		}
	}
}
