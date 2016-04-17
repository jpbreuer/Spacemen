using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    public float lifeTime = 5.0f;
    float startTime;
	
	void Start () {
        startTime = Time.time;
	}
	
	
	void Update () {
        if (Time.time - startTime > lifeTime)
            Destroy(gameObject);
	}
}