using UnityEngine;
using System.Collections;

public class Attract : MonoBehaviour{
	public static Vector3 attract(GameObject obj, float G){
		GameObject[] attractors = GameObject.FindGameObjectsWithTag("Attractor");
		Vector3 gravityForce = Vector3.zero;
		Vector3 dir = Vector3.zero;
        float dist = 0f;
        float mass = 0f;
        if (obj.GetComponent<Rigidbody>() != null)
            mass = obj.GetComponent<Rigidbody>().mass;

		foreach (GameObject att in attractors)
		{
			dir = att.transform.position - obj.transform.position;
			dist = dir.magnitude;
            if (att.GetComponent<Rigidbody>() != null)
			    gravityForce += mass * att.GetComponent<Rigidbody>().mass * G / (dist * dist * dist) * dir;
		}
		return gravityForce;
	}
}