using UnityEngine;
using System.Collections;

public class ActionJump : ActionBase {
	public int nbrJumps = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private Vector3 startPoint;
	public override void Perform(Actor a){
		startPoint = transform.position;
		StartCoroutine ("Performance",a);
	}

	private IEnumerator Performance(Actor a){
		Debug.Log (a.name + " perform action: " + this.name);
		duration = duration / (float)nbrJumps;
		for (int i = 0; i<nbrJumps; i++) {
			//if (Time.time > startTime + duration) {
			
				startTime = Time.time;
				while (Time.time<startTime+duration/(2.0f)) {//(float)i/
				
					a.transform.position = Vector3.Lerp (startPoint, startPoint + Vector3.up,
				                                     (Time.time - startTime) / (duration / 2.0f));
					yield return new WaitForEndOfFrame (); 
				}
				startTime = Time.time;
				while (Time.time<startTime+duration/(2.0f)) {
					a.transform.position = Vector3.Lerp (startPoint + Vector3.up , startPoint,
				                                     (Time.time - startTime) / (duration / 2.0f));
					yield return new WaitForEndOfFrame (); 
				}

		}
		duration = duration * (float)nbrJumps;
		//yield return new WaitForSeconds (duration);
		foreach (Actor next in nextInLine) {
			next.Play ();
			Debug.Log (a.name +"start: " +next.name);
		}

		yield return 0;
	}
}
