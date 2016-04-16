using UnityEngine;
using System.Collections;

public class PlaceText : MonoBehaviour {
    //public static void Label(Rect position, string text);

	// Use this for initialization
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Hello World!");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
