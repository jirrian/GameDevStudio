using UnityEngine;
using System.Collections;

// move sphere where clicked
public class cursorRaycast : MonoBehaviour {

	public Transform sphere;
	Vector3 dest;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			RaycastHit rayHit = new RaycastHit(); // tell where and what raycast hit

			// shoot raycast
			if(Physics.Raycast(ray, out rayHit, 1000f) && Input.GetMouseButtonDown(0)){
				dest = rayHit.point;
			}

			// smoothly move sphere 10% of way
			sphere.position = Vector3.Lerp(sphere.position, dest, 0.1f * Time.deltaTime * 5f);
		//	sphere.position += Vector3.Normalize(dest - sphere.position) * Time.deltaTime *5f;
	}
}
