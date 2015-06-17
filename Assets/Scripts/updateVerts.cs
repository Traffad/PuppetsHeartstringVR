using UnityEngine;
using System.Collections;

public class updateVerts : MonoBehaviour {
	public Color newColor = Color.grey;
	
	void Start () {}
	
	void Update () {
		Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
		
		Color[] colors = new Color[mesh.vertices.Length];
		
		int i = 0;
		while(i < mesh.vertices.Length) {
			colors[i] = newColor;
			i++;
		}
		
		mesh.colors = colors;
	}
}
