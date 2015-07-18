using UnityEngine;
using System.Collections;

public class cameraSwitch : MonoBehaviour {
	public Camera srcCam;
	public Camera destCam;

	public AudioListener srcAud;
	public AudioListener destAud;

	void OnTriggerEnter(){
		// switches from src camera to dest camera
		srcCam.enabled = false;
		destCam.enabled = true;

		srcAud.enabled = false;
		destAud.enabled = true;
	}
}
