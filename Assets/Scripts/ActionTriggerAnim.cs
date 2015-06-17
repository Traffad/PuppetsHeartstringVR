using UnityEngine;
using System.Collections;

public class ActionTriggerAnim : ActionBase {
	public Animator[] anims;
	// Use this for initialization
	void Start () {
	
	}
	
	public override void Perform(Actor a){
		
		Debug.Log (a.name + " perform action: " + this.name + " anims: " + anims.Length);
//		StartCoroutine ("Wait",a);
		foreach (Animator anim in anims) {
			Debug.Log ("Trigger!");
			anim.SetTrigger("StopIdle");//,true);
		}
		foreach (Actor next in nextInLine) {
			next.Play ();
			Debug.Log (a.name+" starts: " +next.name);
		}

	}

}
