using UnityEngine;
using System.Collections;

public class LaserGun : MonoBehaviour { 
    [SerializeField]
    GameObject LaserObject = new GameObject();
    [SerializeField]
    float cooldown = 0.05f;

    int cntr = 0;
    float lastShot = 0;

	// Use this for initialization
	void Start () {
	    
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire") && (Time.time - lastShot) > cooldown)
        {
            Transform fireTransform = transform.FindChild("Gun" + (cntr+1).ToString());
            GameObject laser = (GameObject)Instantiate(LaserObject, fireTransform.position, fireTransform.rotation);
            laser.GetComponent<Rigidbody>().velocity = laser.GetComponent<Rigidbody>().velocity + GetComponent<Rigidbody>().velocity;
            gameObject.GetComponent<AudioSource>().Play();

            cntr++;
            cntr = cntr & 0x03;

            lastShot = Time.time;
        }
    }
}
