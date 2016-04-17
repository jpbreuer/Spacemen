using UnityEngine;
using System.Collections;

public class ProjectileBehavior : MonoBehaviour {
    [SerializeField]
    float ProjectileSpeed = 100.0f;
    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.up * ProjectileSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            contact.otherCollider.gameObject.GetComponent<ObjectBreaker>().Break(contact.point, 500.0f, 5.0f);

        }

        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
