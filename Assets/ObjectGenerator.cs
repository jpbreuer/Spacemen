using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour {
    [SerializeField]
    public GameObject obj;
    [SerializeField]
    public int n = 50;
    [SerializeField]
    public float r = 300;
    [SerializeField]
    public float v = 300;

    // Use this for initialization
    void Start () {
	    for (int i = 0; i < n; i++)
        {
            Instantiate(obj, new Vector3(Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f) * r, new Quaternion(Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f, Random.value * 2.0f - 1.0f));
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
