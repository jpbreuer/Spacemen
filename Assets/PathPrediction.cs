using UnityEngine;
using System.Collections;

public class PathPrediction : MonoBehaviour {
	public int steps = 5;
	public int stepSize = 1;
	float G = 6.67e-3f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject obj = Instantiate(gameObject);
		
		for(int i = 0; i < steps; i++){
			for(int j = 0; j < stepSize; j++){
				obj.GetComponent<Rigidbody>().AddForce(Attract.attract(gameObject, G));
			}
		}
	}
}
