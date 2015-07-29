using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pathInstantiate : MonoBehaviour {
	int counter;
	float rand;

	public Transform floorPrefab;
	public Transform gridInstan;

	float chance1;
	float chance2;
	float chance3;
	float chance4;

	public Color[] colorsFloor;

	public Text reload;

	bool didgrid;	// dont let create grid 2 times in a row

	// Use this for initialization
	void Start () {
		counter = 0;

		chance1 = Random.Range(0f, 1f);
		chance2 = Random.Range(chance1, 1f);
		chance3 = Random.Range(chance2, 1f);

		chance4 = Random.Range(0f, 1f);
		didgrid = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(counter < 100){
			// rotation
			rand = Random.Range(0f,1f);
			if(rand < chance1){
				if(chance4 < 0.15){
					transform.Rotate(0f,-90f,0f);
					didgrid = false;
				}else if(chance4 >= 0.15 && chance4 < 0.35){
					transform.Rotate(0f,90f,0f);
					didgrid = false;
				}else if(chance4 >= 0.35 && chance4 < 0.55){
					if(!didgrid){
						Instantiate(gridInstan, transform.position, transform.rotation);
						didgrid = true;
					}
				}else{
					didgrid = false;
				}

			}else if(rand >= chance1 && rand < chance2){
				if(chance4 < 0.15){
					transform.Rotate(0f,90f,0f);
					didgrid = false;
				}else if(chance4 >= 0.15 && chance4 < 0.35){
					if(!didgrid){
						Instantiate(gridInstan, transform.position, transform.rotation);
						didgrid = true;
					}
				}else if(chance4 >= 0.35 && chance4 < 0.55){
					didgrid = false;
				}else{
					transform.Rotate(0f,-90f,0f);
					didgrid = false;
				}
			}
			else if(rand >= chance2 && rand < chance3){
				if(chance4 < 0.15){
					if(!didgrid){
						Instantiate(gridInstan, transform.position, transform.rotation);
						didgrid = true;
					}
				}else if(chance4 >= 0.15 && chance4 < 0.35){
					didgrid = false;
				}else if(chance4 >= 0.35 && chance4 < 0.55){
					transform.Rotate(0f,-90f,0f);
					didgrid = false;
				}else{
					transform.Rotate(0f,90f,0f);
					didgrid = false;
				}
			}
			else if(rand >= chance3){
				if(chance4 < 0.15){
					didgrid = false;
				}else if(chance4 >= 0.15 && chance4 < 0.35){
					transform.Rotate(0f,-90f,0f);
					didgrid = false;
				}else if(chance4 >= 0.35 && chance4 < 0.55){
					transform.Rotate(0f,90f,0f);
					didgrid = false;
				}else{
					if(!didgrid){
						Instantiate(gridInstan, transform.position, transform.rotation);
						didgrid = true;
					}
				}
			}

			// set color
			Transform newClone = (Transform) Instantiate(floorPrefab, transform.position, transform.rotation);
			newClone.GetComponent<Renderer>().material.color = colorsFloor[Random.Range(0,5)];
			
			transform.localPosition += transform.forward * 5f;
			counter++;
		}
		else{
			//Destroy(this.gameObject);

			reload.text = "Press R to regenerate";
			if(Input.GetKeyDown(KeyCode.R)){
			// RELOAD level
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
