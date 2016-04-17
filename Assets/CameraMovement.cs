using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public GameObject Camera;
    public GameObject GameOver; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            transform.parent = null;

            GameOver.transform.position = Camera.transform.position - new Vector3(10, 30, 50);

        }
    }
}
