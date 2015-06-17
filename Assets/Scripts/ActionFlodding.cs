using UnityEngine;
using System.Collections;

public class ActionFlodding : ActionBase {
	public Transform endDir;
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
		Vector3 startDir = a.transform.up;

		while (Time.time<startTime+duration) {

			a.transform.up = Vector3.Lerp (startDir, endDir.up, (Time.time - startTime) / duration);
			yield return new WaitForEndOfFrame();
		}
		foreach (Actor next in nextInLine) {
			next.Play ();
			Debug.Log (a.name + "start: " +next.name);
		}
		yield return 0;
	}
}
