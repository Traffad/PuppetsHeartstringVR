using UnityEngine;
using System.Collections;

public class ActionPlace: ActionBase {
	
	public Transform EndPoint;
	private Vector3 startPoint;
	public Transform obj;
	public bool endPointParent= false;
//	private RelativeAnimation animObj;
	// Use this for initialization
	void Start () {
//		animObj = (RelativeAnimation)transform.GetComponentInParent<RelativeAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Perform(Actor a){

		StartCoroutine ("Performance",a);
	}

	private IEnumerator Performance(Actor a){
		Debug.Log (a.name + " perform action: " + this.name);
		if (endPointParent)
			obj.SetParent (a.transform.parent,true);
			startTime = Time.time;
		startPoint = obj.position;
			while (Time.time<startTime+duration) {
			if(endPointParent)
				obj.position = Vector3.Lerp (startPoint, EndPoint.position, (Time.time - startTime) / duration);
			else
				obj.position = Vector3.Lerp (startPoint, EndPoint.position, (Time.time - startTime) / duration);

			yield return new WaitForEndOfFrame (); 
			}
		if (endPointParent)
			obj.SetParent (EndPoint,true);

		//yield return new WaitForSeconds (duration);
		foreach (Actor next in nextInLine) {
			next.Play ();
		}

		yield return 0;
	}
}
