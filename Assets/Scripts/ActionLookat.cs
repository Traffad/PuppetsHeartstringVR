using UnityEngine;
using System.Collections;

public class ActionLookat : ActionBase {
	public Transform target;
	public Transform head;
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
			Vector3 endDir = (target.position - a.transform.position).normalized;//Quaternion.FromToRotation(a.transform.rotation.eulerAngles,(EndPoint.position-startPoint).normalized).eulerAngles;
			Vector3 startDir = a.transform.forward;
			Vector3 headStartDir = Vector3.zero;
			if (head != null)
				headStartDir = head.forward;

			while (Time.time<startTime+duration) {
			endDir = (target.position - a.transform.position).normalized;
				float angle = Vector3.Angle (a.transform.forward, endDir);
				if (head != null )
					head.forward = Vector3.Lerp (headStartDir, endDir, 2f * (Time.time - startTime) / duration);
				//a.transform.RotateAround(a.transform.position, Vector3.up,Mathf.Lerp (0, angle,4f*(Time.time - startTime) / duration));// Vector3.Lerp(startRotation,rot,4f*(Time.time - startTime) / duration);
				a.transform.forward = Vector3.Lerp (startDir, endDir, (Time.time - startTime) / duration);
				//Debug.Log("Rotating: " + Vector3.Angle(startDir,endDir));
				//a.transform.position = Vector3.Lerp (startPoint, EndPoint.position, (Time.time - startTime) / duration);
				yield return new WaitForEndOfFrame (); 
			}

		//yield return new WaitForSeconds (duration);
		foreach (Actor next in nextInLine) {
			next.Play ();
			Debug.Log (a.name+"start: " +next.name);
		}
	}
}
