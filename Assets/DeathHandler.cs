using UnityEngine;
using System.Collections;

public class DeathHandler : MonoBehaviour {
    [SerializeField]
    GameObject explosion;

    float health = 100.0f;
	// Use this for initialization
    void OnGUI()
    {
        GUI.skin.label.fontSize = 20;
        GUI.contentColor = Color.green;
        GUI.Label(new Rect(134, Screen.height - 142, 100, 100), ("Health: " + health.ToString("0.")));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.GetComponent<ObjectBreaker>() != null)
            Hurt(Mathf.Pow(collision.impulse.magnitude,1.5f) * 0.5f);
    }

    // Update is called once per frame
    void Hurt (float amount) {
        health -= amount;
        if (health <= 0)
            Die();
    }

    public void Die()
    {
        this.transform.FindChild("Main Camera").transform.FindChild("Plane").GetComponent<Fader>().fadeDown = true;
        this.transform.FindChild("Main Camera").parent = null;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
