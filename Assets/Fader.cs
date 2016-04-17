using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {
    float Delay;

    void Update()
    {
        {
            Delay += Time.deltaTime;
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1.0f - Delay * 0.05f);

            if (transform.GetComponent<SpriteRenderer>().color.a == 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
