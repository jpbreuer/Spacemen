using UnityEngine;
using System.Collections;

public class Movements : MonoBehaviour
{
    public float ThrustSpeed = 10;
    public Vector3 forceVector = new Vector3(0,0,0); 
    
void Update()
    {
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();

        forceVector = new Vector3(Input.GetAxis("Horizontal") * ThrustSpeed, Input.GetAxis("Vertical") * ThrustSpeed, Input.GetAxis("Thrust")* ThrustSpeed);
        forceVector = Quaternion.Euler(this.transform.eulerAngles) * forceVector;
        rigidbody.AddForce(forceVector);

        rigidbody.AddRelativeTorque(new Vector3(Input.GetAxis("Pitch") * ThrustSpeed, 0, Input.GetAxis("Roll") * ThrustSpeed));

        if(Input.GetButton("YawRight"))
        {
        rigidbody.AddRelativeTorque(new Vector3(0,ThrustSpeed,0));
        }

        if (Input.GetButton("YawLeft"))
        {
            rigidbody.AddRelativeTorque(new Vector3(0, -ThrustSpeed, 0));
        }

        rigidbody.angularDrag = 0.4f;
        rigidbody.drag = 0.1f;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //rigidbody.angularVelocity = new Vector3(0, 0, 0);
            //rigidbody.velocity = new Vector3(0, 0, 0);
        }
    }
}