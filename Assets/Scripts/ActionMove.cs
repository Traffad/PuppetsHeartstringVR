using UnityEngine;
using System.Collections;

public class ActionMove : ActionBase {
	
	public Transform EndPoint;
	private Vector3 startPoint;
	public Transform head;
//	private RelativeAnimation animObj;
	// Use this for initialization
	void Start () {
//		animObj = (RelativeAnimation)transform.GetComponentInParent<RelativeAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Perform(Actor a){
		startPoint = a.transform.position;
		StartCoroutine ("Performance",a);
	}

	private IEnumerator Performance(Actor a){
		Debug.Log (a.name + " perform action: " + this.name);
			
			startTime = Time.time;
			//Debug.Log(startPoint + "  endpoint: " +EndPoint.position);
			Vector3 rot = (EndPoint.position-startPoint).normalized;//Quaternion.FromToRotation(a.transform.rotation.eulerAngles,(EndPoint.position-startPoint).normalized).eulerAngles;
		rot = Vector3.ProjectOnPlane (rot, Vector3.up);
		Vector3 startRotation = a.transform.eulerAngles;
		Vector3 headStartDir = Vector3.zero;
		if (head != null)
			headStartDir = head.forward;
			///Debug.Log (transform.parent.name+"'s " +startRotation);
			/*float angle = Vector3.Angle(a.transform.forward,rot);
			Debug.Log(angle);
			angle = angle*Time.deltaTime*duration/4f;
			Debug.Log(angle);
			 */
			Vector3 startDir = a.transform.forward;
			while (Time.time<startTime+duration) {
				//Debug.DrawRay(transform.position,rot);
				//Debug.DrawLine(startPoint,EndPoint.position,Color.green);//,a.transform.forward);
//				animObj.startRotation = startRotation;//Vector3.Lerp(startRotation,rot,(Time.time - startTime) / duration);
				//if(Time.time <startTime+duration/4f)
				//a.transform.RotateAround(a.transform.position, Vector3.up,angle);//Mathf.Lerp (0, angle,4f*(Time.time - startTime) / duration));// Vector3.Lerp(startRotation,rot,4f*(Time.time - startTime) / duration);
			//	float angle = Vector3.Angle(a.transform.forward,rot);
			if(head != null)
				head.forward = Vector3.Lerp(headStartDir,rot,6f*(Time.time - startTime) / duration);
				//a.transform.RotateAround(a.transform.position, Vector3.up,Mathf.Lerp (0, angle,4f*(Time.time - startTime) / duration));// Vector3.Lerp(startRotation,rot,4f*(Time.time - startTime) / duration);
				a.transform.forward = Vector3.Lerp(startDir,rot,4f*(Time.time - startTime) / duration);
				a.transform.position = Vector3.Lerp (startPoint, EndPoint.position, (Time.time - startTime) / duration);
				yield return new WaitForEndOfFrame (); 
			}

		//yield return new WaitForSeconds (duration);
		foreach (Actor next in nextInLine) {
			next.Play ();
		}

		yield return 0;
	}
}
