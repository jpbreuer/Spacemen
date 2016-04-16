using UnityEngine;
using System.Collections;

public class HeightMap : MonoBehaviour {
	public Vector3 Pos;

    void Start() {


    }


	// Update is called once per frame
	void Update () {
        // Obtain mesh of the attached component
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        // Save vertices in "vertices"
        Vector3[] vertices = mesh.vertices;

        int i = 0;

        while (i < vertices.Length) {
            // 
            vertices[i] += Vector3.up * Time.deltaTime;
            i++;
        }
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }
}
