using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeGenerator : MonoBehaviour {
	public static List<List<GameObject>> cubes=new List<List<GameObject>>();
	// Use this for initialization
	void Start () {
		generateCubes(20,36);
	}
		
	public static void generateCubes(int z, int x){
		foreach (List<GameObject> currentList in cubes) {
			foreach (GameObject go in currentList) {
				Destroy (go);
				}
			}
		cubes=new List<List<GameObject>>();
		for (int i = 0; i < x; i++) {
			List<GameObject> currentRow = new List<GameObject>();
			for (int j = 0; j < z; j++) {
				GameObject go = Instantiate (Resources.Load ("cube_prefab"), new Vector3 (j*0.25f, 0, i*0.25f), Quaternion.identity) as GameObject;
				currentRow.Add (go);
			}
			cubes.Add (currentRow);
		}
	}



	// Update is called once per frame
	void Update () {

	}
}
