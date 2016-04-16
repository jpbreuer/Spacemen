using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
public class PlanetDeform : MonoBehaviour {
	Mesh mesh;
	Vector3[] originalVertices;
	Vector3[] newVertices;
	
	public float Scale = 1f;
	public float PerturbAmount = 0.2f;
	
	void Start () {
		GetComponent<Rigidbody>().mass = Scale*Scale*Scale*10;
		GetComponent<SphereCollider>().radius = 0.5f*Scale;
		Debug.Log("Size: " + Scale + " , Mass: " + GetComponent<Rigidbody>().mass);
		mesh = GetComponent<MeshFilter>().mesh;
		//mesh = Resources.Load<Mesh>("Assets/Asteroids/Planet.obj");
		originalVertices = mesh.vertices;
		newVertices = originalVertices;
		for(int i = 0; i < originalVertices.Length; i++){
			newVertices[i] = Scale*originalVertices[i]*(1F-PerturbAmount/2 + Random.value*PerturbAmount);
		}
		mesh.vertices = newVertices;
		mesh.RecalculateNormals();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
