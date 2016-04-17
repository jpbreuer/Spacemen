using UnityEngine;
using System.Collections;

public class EngineSound : MonoBehaviour {
	public AudioClip clip;
	public float MaxSpeed = 25f;
    public float MinSpeed = 0.01f;

    AudioSource au;
	// Use this for initialization
	void Start () {
		au = gameObject.AddComponent<AudioSource>();
		au.clip = clip;
		au.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = GetComponent<Rigidbody>().velocity;
		if(au.isPlaying){
			if(v.magnitude < MinSpeed)
            {
				au.Stop();
            }
            else// if(v.magnitude < MaxSpeed)
            {
				au.pitch = v.magnitude/MaxSpeed;
				au.volume = v.magnitude/MaxSpeed;
            }
		}
        if (!au.isPlaying)
        {
			if(v.magnitude > MinSpeed)
            {
				au.Play();
			}
		}
	}
}
