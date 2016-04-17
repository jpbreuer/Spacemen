using UnityEngine;
using System.Collections;

public class SolarDestruction : MonoBehaviour {
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ObjectBreaker>() != null)
            Destroy(collision.gameObject);
        if (collision.gameObject.tag == "Ship")
            collision.gameObject.GetComponent<DeathHandler>().Die();
    }
}
