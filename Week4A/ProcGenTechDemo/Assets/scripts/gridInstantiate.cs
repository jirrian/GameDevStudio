using UnityEngine;
using System.Collections;

public class gridInstantiate : MonoBehaviour {
	float rand;

	public Transform floorPrefab;
	public Transform wallPrefab;
	public Transform floorInstan;

	float chance1;
	float temp;

	int wallCount;	// limit # of walls per grid

	Color[] colorsFloor;
	public Color[] colorsWall;
	// Use this for initialization
	void Start () {
		wallCount = 0;
		chance1 = Random.Range(0f, 1f);

		// so its more likely to produce floors than walls
		if(chance1 < (1f - chance1)){
			chance1 = 1f - chance1;
		}

		colorsFloor = floorInstan.GetComponent<pathInstantiate>().colorsFloor;

			for(int i = 0; i < 5; i++){
				for(int j = 0; j < 5; j++){
					Vector3 pos = new Vector3(i * 5f, 0f, j * 5) + transform.position;
					rand = Random.Range(0f, 1f);
					if(rand < chance1){
						// change color
						Transform newClone = (Transform) Instantiate(floorPrefab, pos, transform.rotation);
						newClone.GetComponent<Renderer>().material.color = colorsFloor[Random.Range(0,5)];
					}
					else if(rand >= chance1){
						if(wallCount < 13){
							// change color
							Transform newClone = (Transform) Instantiate(wallPrefab, pos, transform.rotation);
							newClone.GetComponent<Renderer>().material.color = colorsWall[Random.Range(0,4)];
							wallCount++;
						}
					}
				}
			}
			//Destroy(this.gameObject);
	}

}
