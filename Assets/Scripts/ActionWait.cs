using UnityEngine;
using System.Collections;

public class ActionWait : ActionBase {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public override void Perform(Actor a){
		StartCoroutine ("Wait",a);
	}
	private IEnumerator Wait(Actor a){
			Debug.Log (a.name + " perform action: " + this.name);
		yield return new WaitForSeconds (duration);
			//yield return new WaitForSeconds (duration);
		foreach (Actor next in nextInLine) {
			next.Play ();
			Debug.Log (a.name +"start: " +next.name);
		}

			yield return 0;
		}

}
