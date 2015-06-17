
using UnityEngine;
using System.Collections;


public class StoryController : MonoBehaviour {

/*	public struct Scene{
		public int nbr;
		public Actor[] myActors;
	}*/
  	
  	public Scene[] scenes;
	private bool playerActive = true;
	private int currentScene = 0;
	// Use this for initialization
	void Start () {
		//StartCoroutine ("WaitForPlayer");
		BeginScene (scenes [currentScene]);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			playerActive = !playerActive;
			Debug.Log ("playerActive: " + playerActive);
		}

	}
	float startTime= float.MinValue;


	IEnumerator WaitForPlayer(){
		if (!playerActive) {

			foreach (Actor a in scenes[currentScene].myActors)
				a.Wait ();

			while (!playerActive) {//currentScene < scenes.Length) {
				yield return new WaitForSeconds (0.1f);
				if (currentScene == 10 || currentScene == 27) {
//				daytime = false;

				}

			}
			foreach (Actor a in scenes[currentScene].myActors) {
				a.StopWaiting ();
				a.StopAllCoroutines ();
			}
		}
			currentScene++;
		if (currentScene < scenes.Length)
			BeginScene (scenes [currentScene]);
		yield return 0;
	}

	public void EndScene(int sceneNbr){
/*		if (playerActive) {
			if (currentScene < scenes.Length)
				BeginScene (scenes [currentScene]);
		} else*/
			StartCoroutine ("WaitForPlayer");
	}

	private void BeginScene(Scene scene){
		Debug.Log ("Begin Scene: " + currentScene);
		foreach (Actor actor in scene.myActors) {
				actor.Play ();
		}
	}
}

