using UnityEngine;
using System.Collections;

public class AffectedByGravity : MonoBehaviour {
    [SerializeField] private float G = 6.67e1f;

    // Update is called once per frame
    void Update ()
    {
        if (gameObject.GetComponent<Rigidbody>() != null)
            gameObject.GetComponent<Rigidbody>().AddForce(Attract.attract(gameObject, G));
	}
}
