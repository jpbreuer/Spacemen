using UnityEngine;
using System.Collections;

public class LaserGun : MonoBehaviour {
    bool currentFireButton = false; bool lastFireButton = false;
    [SerializeField]
    GameObject LaserObject = new GameObject();
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        currentFireButton = Input.GetButton("Fire");

        if (currentFireButton && !lastFireButton)
        {
            Transform fireTransform1 = transform.FindChild("Gun1");
            GameObject laser = (GameObject)Instantiate(LaserObject, fireTransform1.position, fireTransform1.rotation);
        }

        

        lastFireButton = currentFireButton;
    }
}
