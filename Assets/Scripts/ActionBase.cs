using UnityEngine;
using System.Collections;

public abstract class ActionBase : MonoBehaviour {
	public Actor[] nextInLine;
	public float duration = 0.0f;
	public float delayStartTime = 0.0f;
	protected float startTime= float.MinValue;
	// Use this for initialization
	void Start () {
		if (duration == 0.0f)
			Debug.LogError ("set duration for this Action");
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void Begin(Actor a){

		StartCoroutine ("Delay", a);

	}

	IEnumerator Delay(Actor a){
		yield return new WaitForSeconds (delayStartTime);
		Perform (a);
		yield return 0;
	}

	public abstract void Perform(Actor a);

	/*private IEnumerable Performance(){
		yield return new WaitForSeconds (duration);
		nextInLine.Play ();
	}*/

}
