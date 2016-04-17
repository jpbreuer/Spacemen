using UnityEngine;
using System.Collections;

public class ThrusterLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Light>().intensity = Mathf.Abs(Input.GetAxis("Thrust") * 10.0f);
    }
}
