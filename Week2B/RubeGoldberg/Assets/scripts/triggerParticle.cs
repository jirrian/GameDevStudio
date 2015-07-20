using UnityEngine;
using System.Collections;

public class triggerParticle : MonoBehaviour {
	public ParticleSystem particleSystem;

	void OnTriggerEnter(){
		particleSystem.Play();
	}

}
