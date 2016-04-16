using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    public GameObject target;
    public Vector3 offset;

    void Start()
    {
        offset = target.transform.position - new Vector3(0,10,25);
    }

    void Update ()
    {
        Quaternion rotation = Quaternion.Euler(target.transform.eulerAngles.x, target.transform.eulerAngles.y, target.transform.eulerAngles.z);

        transform.position = target.transform.position - (rotation * offset);
        transform.LookAt(target.transform);
    }
}
