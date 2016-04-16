using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    
        void Update ()
    {

        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y+10, target.transform.position.z + 25);

    }
}
