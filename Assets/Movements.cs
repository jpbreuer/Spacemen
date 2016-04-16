using UnityEngine;
using System.Collections;

public class Movements : MonoBehaviour
{
    public float ThrustSpeed = 30;
    public Vector3 forceVector = new Vector3(0,0,0); 
    
void Update()
    {
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();

        forceVector = new Vector3(Input.GetAxis("Horizontal") * ThrustSpeed, Input.GetAxis("Vertical") * ThrustSpeed, Input.GetAxis("Thrust")* ThrustSpeed);
        forceVector = Quaternion.Euler(this.transform.eulerAngles) * forceVector;
        rigidbody.AddForce(forceVector);

        rigidbody.AddRelativeTorque(new Vector3(Input.GetAxis("Pitch") * ThrustSpeed / 20, Input.GetAxis("Yaw") * ThrustSpeed / 20,0));

        if(Input.GetButton("RollRight"))
        {
        rigidbody.AddRelativeTorque(new Vector3(0,0,ThrustSpeed/20));
        }

        if (Input.GetButton("RollLeft"))
        {
            rigidbody.AddRelativeTorque(new Vector3(0, 0, -ThrustSpeed / 10));
        }

        rigidbody.angularDrag = 0.4f;
        rigidbody.drag = 0.4f;
    }
}