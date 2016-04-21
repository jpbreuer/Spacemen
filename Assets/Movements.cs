using UnityEngine;
using System.Collections;

public class Movements : MonoBehaviour
{
    public float ThrustSpeed = 10;
    public Vector3 forceVector = new Vector3(0,0,0); 
    
void Update()
    {
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();

        //forceVector = new Vector3(Input.GetAxis("Horizontal") * ThrustSpeed, Input.GetAxis("Vertical") * ThrustSpeed, Input.GetAxis("Thrust")* ThrustSpeed);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            forceVector = new Vector3(0, 0, ThrustSpeed);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            forceVector = new Vector3(0, 0, -ThrustSpeed);
        }
        forceVector = Quaternion.Euler(this.transform.eulerAngles) * forceVector;
        rigidbody.AddForce(forceVector);

        //Pitch
        if (Input.GetKey("w"))
        {
            rigidbody.AddRelativeTorque(new Vector3(ThrustSpeed/2, 0, 0));       
        }
        if (Input.GetKey("s"))
        {
            rigidbody.AddRelativeTorque(new Vector3(-ThrustSpeed, 0, 0));
        }

        //Yaw
        if (Input.GetKey("d"))
        {
            rigidbody.AddRelativeTorque(new Vector3(0, ThrustSpeed/2, 0));
        }
        if (Input.GetKey("a"))
        {
            rigidbody.AddRelativeTorque(new Vector3(0, -ThrustSpeed/2, 0));
        }

        //Roll
        if (Input.GetKey("q"))
        {
            rigidbody.AddRelativeTorque(new Vector3(0, 0, ThrustSpeed/2));
        }
        if (Input.GetKey("e"))
        {
            rigidbody.AddRelativeTorque(new Vector3(0, 0, -ThrustSpeed/2));
        }



        //rigidbody.AddRelativeTorque(new Vector3(Input.GetAxis("Pitch") * ThrustSpeed, 0, Input.GetAxis("Roll") * ThrustSpeed));

        //if(Input.GetButton("YawRight"))
        //{
        //rigidbody.AddRelativeTorque(new Vector3(0,ThrustSpeed,0));
        //}

        //if (Input.GetButton("YawLeft"))
        //{
        //    rigidbody.AddRelativeTorque(new Vector3(0, -ThrustSpeed, 0));
        //}

        rigidbody.angularDrag = 0.4f;
        rigidbody.drag = 0.1f;
    }
}