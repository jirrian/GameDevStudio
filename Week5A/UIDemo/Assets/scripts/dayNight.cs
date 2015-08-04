using UnityEngine;
using System.Collections;

public class dayNight : MonoBehaviour {

	public Light sun;
	public float currentTime = 0f;	// value from 0-1, 0 midnight, 1 is noon
	float speed = 1f;
	public Vector3 highNoonRotation, midnightRotation;
	public Color highNoonColor, midnightColor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// LERP = linear interpolation
		sun.transform.rotation = Quaternion.Lerp(Quaternion.Euler(midnightRotation), Quaternion.Euler(highNoonRotation), currentTime);
		sun.color = Color.Lerp(highNoonColor, midnightColor, currentTime);

		currentTime = Mathf.Abs(Mathf.Sin(Time.time * speed));
	}

	// have slider fill in currTime with its slider value
	public void ChangeTimeOfDay(float currTime){
		currentTime = currTime;
	}

		// have slider fill in currTime with its slider value
	public void ChangeTimeSpeed(float currSpeed){
		speed = currSpeed;
	}
}
