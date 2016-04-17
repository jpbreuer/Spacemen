using UnityEngine;
using System.Collections;

public class PlaceText : MonoBehaviour {
    //public static void Label(Rect position, string text);

    public float Score = 0.2f;
    public float Thrust = 50f;
    //public GUIStyle labelStyle;

	// Use this for initialization
    void OnGUI(){
        string s_score = Score.ToString("R");
        string s_thrust = Thrust.ToString("R");

        string str_score = "Score: " + s_score;
        string str_thrust = "Thrust: " + s_thrust;

        GUI.Label(new Rect(10, 10, 100, 20), str_score);
        GUI.Label(new Rect(10, 30, 100, 20), str_thrust);
        //GUI.Label(new Rect(10, 10, 100, 20), str_score, labelStyle);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
