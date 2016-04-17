using UnityEngine;
using System.Collections;

public class PlaceText : MonoBehaviour {
    //public static void Label(Rect position, string text);

    public float Score = 0.2f;
    public float Thrust = 50f;
    //public GUIStyle labelStyle;

	// Use this for initialization
    void OnGUI(){
        GameObject Ship = gameObject;
		Vector3 vel = Ship.GetComponent<Rigidbody>().velocity;
		Vector3 velLocal = Ship.transform.worldToLocalMatrix*vel;
        velLocal.z = -velLocal.z;
        velLocal.x = -velLocal.x;

        Texture forwardSpeed = Resources.Load<Texture>("forwardSpeed");
		Texture upwardSpeed = Resources.Load<Texture>("upwardSpeed");
		Texture rightSpeed = Resources.Load<Texture>("rightSpeed");		
		Texture speedGauge = Resources.Load<Texture>("SpeedGauge");		
		
        string s_score = Score.ToString("R");
        string s_thrust = Thrust.ToString("R");

        string str_score = "Score: " + s_score;
        string str_thrust = "Thrust: " + s_thrust;

       // GUI.Label(new Rect(10, 10, 100, 20), str_score);
       // GUI.Label(new Rect(10, 30, 100, 20), str_thrust);
		
		GUI.Label(new Rect(10, Screen.height-150, forwardSpeed.width, forwardSpeed.height), forwardSpeed);
		GUI.Label(new Rect(50, Screen.height-150, forwardSpeed.width, forwardSpeed.height), upwardSpeed);
		GUI.Label(new Rect(90, Screen.height-150, forwardSpeed.width, forwardSpeed.height), rightSpeed);
        float centerY = Screen.height - 142 + speedGauge.height;

        float scaleSpeed = 150;
        float topZ = speedGauge.height*velLocal.z/scaleSpeed;
		float topY = speedGauge.height*velLocal.y/scaleSpeed;
		float topX = speedGauge.height*velLocal.x/scaleSpeed;
	
        if (velLocal.z >= 0)
		    GUI.Label(new Rect(14, centerY - topZ, speedGauge.width, speedGauge.height*velLocal.z/scaleSpeed), speedGauge);
        else
            GUI.Label(new Rect(14, centerY - topZ + speedGauge.height * velLocal.z / scaleSpeed, speedGauge.width, -speedGauge.height * velLocal.z / scaleSpeed), speedGauge);

        if (velLocal.y >= 0)
            GUI.Label(new Rect(54, centerY - topY, speedGauge.width, speedGauge.height*velLocal.y/scaleSpeed), speedGauge);
        else
            GUI.Label(new Rect(54, centerY - topY + speedGauge.height * velLocal.y / scaleSpeed, speedGauge.width, -speedGauge.height * velLocal.y / scaleSpeed), speedGauge);

        if (velLocal.x >= 0)
            GUI.Label(new Rect(94, centerY-topX, speedGauge.width, speedGauge.height*velLocal.x/scaleSpeed), speedGauge);
        else
            GUI.Label(new Rect(94, centerY - topX + speedGauge.height * velLocal.x / scaleSpeed, speedGauge.width, -speedGauge.height * velLocal.x / scaleSpeed), speedGauge);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
