using UnityEngine;
using System.Collections;

public class ActionToggleAction : ActionBase {
	public GameObject[] Toggle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	
	// Update is called once per frame
	public override void Perform(Actor a){
		Debug.Log (a.name + " perform action: " + this.name);
		foreach (GameObject obj in Toggle) {
			obj.SetActive (!obj.activeSelf);
		}
		foreach (Actor next in nextInLine) {
			next.Play ();
			Debug.Log (a.name +"start: " +next.name);
		}
	}

}
