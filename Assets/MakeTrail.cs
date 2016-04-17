using UnityEngine;
using System.Collections;

public class MakeTrail : MonoBehaviour {
	public int TailLength = 100;
	public float TailWidth = 0.05f;
    public Camera camera;
	
	public ArrayList tailSegments;
    public ArrayList tailIntensities;
    GameObject Tail;
	public GameObject Ship;
	public Material mat;
	// Use this for initialization
	void Start () {
		tailSegments = new ArrayList();
        tailIntensities = new ArrayList();
        Vector3 p = Ship.transform.position;
		for(int i = 0; i < TailLength; i++){
			tailSegments.Add(p);
            tailIntensities.Add(0.0f);

        }
		Tail = new GameObject("tail");
		Tail.AddComponent<MeshFilter>();
		Tail.AddComponent<MeshRenderer>();
		Tail.GetComponent<MeshRenderer>().material = mat;
    }
	
	// Update is called once per frame
	void Update () {
        Tail.GetComponent<MeshFilter>().mesh.bounds = new Bounds(camera.transform.position, Vector3.one);

        tailSegments.RemoveAt(0);
        tailSegments.Add(Ship.transform.position);

        tailIntensities.RemoveAt(0);
        tailIntensities.Add(Mathf.Abs(Input.GetAxis("Thrust")));

        Mesh mesh = Tail.GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = new Vector3[3*TailLength];
		Vector2[] uv = new Vector2[3*TailLength];
		int[] triangles = new int[3*6*(TailLength-1)];
		
		//Calculate the vertices
		for(int i = 0; i < TailLength; i++){
            float r = (TailWidth - (TailLength - i - 1) * TailWidth / TailLength) * (float)tailIntensities[i] * 0.5f;
			Vector3 dir = ((Vector3) tailSegments[Mathf.Min(TailLength-1, i+1)] - (Vector3) tailSegments[Mathf.Max(0, i-1)]);
			Vector3 a1 = Vector3.Cross(dir, Vector3.up);
			a1.Normalize();
			a1*=r;
			Vector3 a2 = Quaternion.AngleAxis(120, dir)*a1 + (Vector3) tailSegments[i];
			Vector3 a3 = Quaternion.AngleAxis(240, dir)*a1 + (Vector3) tailSegments[i];
			a1 += (Vector3) tailSegments[i];
			vertices[3*i]   = a1;
			vertices[3*i+1] = a2;
			vertices[3*i+2] = a3;
			uv[3*i] = new Vector3(1, 1);
			uv[3*i+1] = new Vector3(1, 0);
			uv[3*i+2] = new Vector3(0, 0);
		}
		//Calculate the faces
		for(int i = 0; i < TailLength-1; i++){
			triangles[18*i] = 3*i;			triangles[18*i+1] = 3*i+4; 	    triangles[18*i+2] = 3*i+1;
			triangles[18*i+3] = 3*i;		triangles[18*i+4] = 3*i+3; 	    triangles[18*i+5] = 3*i+4;
			triangles[18*i+6] = 3*i+1;		triangles[18*i+7] = 3*i+5; 	    triangles[18*i+8] = 3*i+2;
			triangles[18*i+9] = 3*i+1;		triangles[18*i+10] = 3*i+4; 	triangles[18*i+11] = 3*i+5;
			triangles[18*i+12] = 3*i+2;	    triangles[18*i+13] = 3*i+3; 	triangles[18*i+14] = 3*i;
			triangles[18*i+15] = 3*i+2;	    triangles[18*i+16] = 3*i+5; 	triangles[18*i+17] = 3*i+3;
		}

		mesh.vertices = vertices;
		//mesh.uv = uv;
		mesh.triangles = triangles;
		//mesh.RecalculateNormals();
	}
}