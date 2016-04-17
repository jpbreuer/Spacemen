using UnityEngine;
using System.Collections;

public class SolarDestruction : MonoBehaviour {
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ObjectBreaker>() != null)
            Destroy(collision.gameObject);
    }
}
