using UnityEngine;
using System.Collections;
using System.Collections.Generic;	// use Lists

public class procgenDemo : MonoBehaviour {
	// instantiation - cloning existing prefabs

	public Transform prefab;	// assign in inspector
	public List<Transform> listOfClones = new List<Transform>();

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 100; i++){
			// cast object to transform
			Transform newClone = (Transform) Instantiate(prefab, Random.insideUnitSphere * 5f, Quaternion.Euler(0f, Random.Range(0f,360f), 0f));
			newClone.localScale = new Vector3(Random.Range(0.5f,1f), 
												Random.Range(0.5f,2f),
												Random.Range(0.5f,1f)
												);
			Debug.Log(i);
			listOfClones.Add(newClone);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
		// RELOAD level
			Application.LoadLevel(Application.loadedLevel);
		}

		if(Input.GetKeyDown(KeyCode.Space)){
		/*	for(int i = 0; i < listOfClones.Count; i++){
				listOfClones[i].localScale *= 2f;
			}
		*/
			foreach(Transform clone in listOfClones){
				clone.localScale *= 2f;
			}
		}

	}
}
