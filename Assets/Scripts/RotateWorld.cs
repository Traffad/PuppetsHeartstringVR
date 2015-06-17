using UnityEngine;
using System.Collections;

public class RotateWorld : MonoBehaviour {
	public float duration = 5.0f;
	public float angles = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			StartCoroutine ("Rotate");
		}
	}
	float startTime= float.MinValue;
	IEnumerator Rotate(){
		if (Time.time > startTime + duration) {

			startTime = Time.time;
	
			while (Time.time<startTime+duration) {
				Debug.Log ("rotate Func" + angles * Time.deltaTime);
				transform.RotateAroundLocal (Vector3.up, angles * Time.deltaTime);
				yield return new WaitForEndOfFrame ();    
			}
		}
		yield return 0;
	}

}
