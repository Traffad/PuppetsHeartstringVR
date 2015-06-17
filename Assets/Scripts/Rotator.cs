using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
	
	public bool isActive = false;
	public float speed = 0.33f;
	
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	
	// Update is called once per frame
	void Update ()
	{
		if ( isActive )
			transform.RotateAroundLocal( Vector3.up, 0.33f * Time.deltaTime );
	}
}
