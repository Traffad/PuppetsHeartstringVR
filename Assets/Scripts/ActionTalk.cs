using UnityEngine;
using System.Collections;

public class ActionTalk : ActionBase {

	public AudioClip sound;

	// Use this for initialization
	void Start () {
	
	}
	
	public override void Perform(Actor a){
		StartCoroutine ("Performance",a);
	}
	
	private IEnumerator Performance(Actor a){
		Debug.Log (a.name + " perform action: " + this.name + " sound: " + sound.name);
		if (a.headAnim != null)
			a.headAnim.SetBool ("talking",true);
		AudioSource soundSource = a.GetComponent<AudioSource> ();
		//Debug.Log (soundSource.clip.name);
		soundSource.clip = sound;

		soundSource.Play ();
		yield return new WaitForSeconds (sound.length);
		if (a.headAnim != null)
			a.headAnim.SetBool ("talking",false);
		foreach (Actor next in nextInLine) {
			next.Play ();
			Debug.Log (a.name +"start: " +next.name);
		}
	}

}
