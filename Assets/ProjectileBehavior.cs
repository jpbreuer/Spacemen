using UnityEngine;
using System.Collections;

public class ProjectileBehavior : MonoBehaviour {
    [SerializeField]
    float ProjectileSpeed = 100.0f;
    [SerializeField]
    GameObject obj;
    float startTime = 0;
    float lifeTime = 5f;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.up * ProjectileSpeed);
        startTime = Time.time;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ObjectBreaker>() != null)
            collision.gameObject.GetComponent<ObjectBreaker>().Break(transform.position, 500.0f, 5.0f);
         
        Instantiate(obj, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    // Update is called once per frame
    void Update () {
        if (Time.time - startTime > lifeTime)
            Destroy(gameObject);
	}
}
