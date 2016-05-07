using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
using System.Threading;


public class CubeBehaviourScript : MonoBehaviour {
	private int up=0;
	public Vector3 pos;
	public float distance = 1.0f;
	void Start () {
		Color newColor = new Color (Random.value, Random.value, Random.value, 1.0f);
		Renderer rend = GetComponent<Renderer> ();
		rend.material.color = newColor;
		StartCoroutine(takePause());
	}

	IEnumerator takePause(){
		print (Time.time);
		yield return new WaitForSeconds(Random.Range(0,10));	
		up = 1;
		print (Time.time);
	}

	// Update is called once per frame
	void Update () {
		pos = Camera.main.WorldToScreenPoint (new Vector3 (transform.position.x + 0.125f, 0, transform.position.z + 0.125f)) -
		Input.mousePosition;
		distance =  Mathf.Sqrt(Mathf.Pow(pos.x,2) + Mathf.Pow(pos.y,2));
		if (distance < 50f) {
			transform.position = new Vector3 (transform.position.x, 2f - distance / 25, transform.position.z);
		} else {
			if (up != 0) {
				float currentPos = transform.position.y;
				if (currentPos < 0) {
					up = 1;
				} 
				if (currentPos > 0.5f) {
					up = -1;
				}
				setTransformY (0.01f * up);
			}
		}
	}

	void setTransformY(float n){
		transform.position = new Vector3 (transform.position.x,transform.position.y+n,transform.position.z);
	}
}
