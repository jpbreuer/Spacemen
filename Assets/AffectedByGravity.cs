using UnityEngine;
using System.Collections;

public class AffectedByGravity : MonoBehaviour {
    [SerializeField] private float G = 6.67e-2f;
    [SerializeField] private Vector3 startingVelocity = new Vector3(0,0,0);

    void Start()
    {
        this.GetComponent<Rigidbody>().velocity = startingVelocity;
    }

    // Update is called once per frame
    void Update () {
        this.GetComponent<Rigidbody>().AddForce(Attract.attract(gameObject, G));
	}
}
