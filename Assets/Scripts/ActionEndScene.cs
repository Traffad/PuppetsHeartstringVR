using UnityEngine;
using System.Collections;

public class ActionEndScene : ActionBase {

	// Use this for initialization
	private StoryController myController;
	public int scene;
	void Start () {

		myController = GetComponentInParent<StoryController>();
		if (myController == null)
			Debug.LogError ("storycontroller not found for " + gameObject.name); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Perform(Actor a){
		Debug.Log (a.name + " perform action: " + this.name);
		myController.EndScene (scene);
	}
}
