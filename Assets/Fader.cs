using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {
    float Delay = 0.0f;
    public bool fadeDown = false;
    string message = "";

    void Update()
    {
        {
            if (fadeDown)
            {
                Delay -= Time.deltaTime * 0.15f;
                if (Delay < 0)
                {
                    message = "Press A to restart or B to quit!";
                    if (Input.GetButton("Fire"))
                        Application.LoadLevel(Application.loadedLevelName);
                    else if (Input.GetButton("Back"))
                        Application.Quit();
                }
                GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1.0f - Delay);
            }
            else
            {
                Delay += Time.deltaTime * 0.05f; if (Delay > 1) Delay = 1;
                GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1.0f - Delay);
            }

        }
    }

    void OnGUI()
    {
        GUI.contentColor = Color.green;
        GUI.skin.label.fontSize = 48;
        GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height - Screen.height/2, 1000, 100), message);
    }

}
