using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

	public ActionBase[] actions;
	public ActionBase[] WaitCycle;
	public int currentAction = 0;
	private int currentWaitAction = 0;
	private bool waiting = false;
	public Animator headAnim;
	// Use this for initialization

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Play(){
		//Debug.Log ("play: " + this.name);
		if (waiting) {
			Wait ();
			return;
		}
		if (currentAction < actions.Length) {
			//Debug.Log (this.name + " Call perform "+actions[currentAction].name);
			currentAction++;
		//	Debug.Log (actions.Length + " current: " + currentAction);
			actions [currentAction - 1].Begin (this);
			//Debug.Log (this.name + " increase current action");

		} else
			Debug.Log (this.name + " out of actions. Last action :");// + actions [currentAction - 1].name);

	}

	public void Wait(){
		Debug.Log (this.name + " is waiting");
		waiting = true;
		if (WaitCycle.Length == 0)
			return;
		if (currentWaitAction >= WaitCycle.Length)
			currentWaitAction = 0;
			
		WaitCycle [currentWaitAction].Begin (this); 
	}

	public void StopWaiting(){
		waiting = false;
		if (currentWaitAction >= WaitCycle.Length)
			return;
		Debug.Log ("StopWaiting");
		WaitCycle [currentWaitAction].StopAllCoroutines (); 
	}
}
