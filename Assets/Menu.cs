using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    GameObject[] pauseObjects;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p") && Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown("p") && Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}