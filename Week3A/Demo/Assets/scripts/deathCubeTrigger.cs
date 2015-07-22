using UnityEngine;
using System.Collections;

public class deathCubeTrigger : MonoBehaviour {
	public ParticleSystem fire;

	// delete player if enter trigger
	void OnTriggerEnter(Collider thing){
		Destroy(thing.gameObject);	// delete game object

		fire.Play(); // start particle system
	}
}
