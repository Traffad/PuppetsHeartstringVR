using UnityEngine;
using System.Collections;

public class ActionScale : ActionBase {
	public float endScaleY=0.265f;
	public Transform ScaleThisY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public override void Perform(Actor a){
		StartCoroutine ("Performance",a);
	}
	
	private IEnumerator Performance(Actor a){
		Debug.Log (a.name + " perform action: " + this.name);
		//if (Time.time > startTime + duration) {
		
		startTime = Time.time;
		//Debug.Log(startPoint + "  endpoint: " +EndPoint.position);
		//Vector3 endDir = (target.position - a.transform.position).normalized;//Quaternion.FromToRotation(a.transform.rotation.eulerAngles,(EndPoint.position-startPoint).normalized).eulerAngles;
		Vector3 startScale = ScaleThisY.localScale;
		Vector3 endScale = new Vector3 (startScale.x, endScaleY, startScale.z);
		while (Time.time<startTime+duration) {
			ScaleThisY.localScale = Vector3.Lerp (startScale, endScale, (Time.time - startTime) / duration);
			yield return new WaitForEndOfFrame();
		}
		foreach (Actor next in nextInLine) {
			next.Play ();
				Debug.Log (a.name + "start: " +next.name);
		}
		yield return 0;
	}
}
