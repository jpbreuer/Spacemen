using UnityEngine;
using System.Collections;

public class NewBehaviourScript1 : MonoBehaviour {
    float angle = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        angle += 0.01f;

        this.transform.position = new Vector3(Mathf.Cos(angle), 1, Mathf.Sin(angle)) * 2;
	}
}
