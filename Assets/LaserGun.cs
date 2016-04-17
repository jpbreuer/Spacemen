using UnityEngine;
using System.Collections;

public class LaserGun : MonoBehaviour {
    bool currentFireButton = false; bool lastFireButton = false;
    [SerializeField]
    GameObject LaserObject = new GameObject();
    int cntr = 0;

	// Use this for initialization
	void Start () {
	    
	}

	// Update is called once per frame
	void Update () {
        currentFireButton = Input.GetButton("Fire");

        if (currentFireButton && !lastFireButton)
        {
            if ((cntr & 0x01) == 0)
            {
                Transform fireTransform = transform.FindChild("Gun1");
                Instantiate(LaserObject, fireTransform.position, fireTransform.rotation);
            }
            else
            {
                Transform fireTransform = transform.FindChild("Gun2");
                Instantiate(LaserObject, fireTransform.position, fireTransform.rotation);
            }

            cntr++;
        }

        lastFireButton = currentFireButton;
    }
}
