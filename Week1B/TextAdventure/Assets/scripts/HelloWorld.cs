using UnityEngine;
using System.Collections;
using UnityEngine.UI;	// import package for UI

public class HelloWorld : MonoBehaviour {
	public Text myTextObject;	// where the Text UI object is

	// Use this for initialization
	void Start () {
		Debug.Log("Hello World");
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Bonjour Monde");
		myTextObject.text += "Hola Mundo";
	}
}
