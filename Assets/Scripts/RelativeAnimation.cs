using UnityEngine;
using System.Collections;

public class RelativeAnimation : MonoBehaviour {

	public Vector3 relativeRotation= Vector3.zero;
	public Vector3 startRotation= Vector3.zero;
	public bool animateRot = false;
	private bool startRot = false;
	// Use this for initialization
	void Start () {
		startRotation = this.transform.rotation.eulerAngles;
		Debug.Log ("Rel Start"+startRotation);
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log ("Rel Start"+startRotation);
		//Debug.Log ("angle 1"+transform.eulerAngles);
		if (animateRot) {
			if (!startRot) {
				startRot = true;
				//startRotation = this.transform.rotation.eulerAngles;
			}
			//Debug.Log (transform.eulerAngles );
			//transform.localRotation.e
			transform.eulerAngles = (startRotation + relativeRotation);//new Vector3(0,90,0));//(
		//	Debug.Log("rel"+relativeRotation);
	//		Debug.Log ("start "+ startRotation );
		} else
			startRot = false;
	//	Debug.Log ("angle 2"+transform.eulerAngles);
	}
}
