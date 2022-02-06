using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    FixedJoystick joystick;
    public Transform centerOfMass;

    public WheelCollider wheelColliderRightFront;
    public WheelCollider wheelColliderLeftFront;
    public WheelCollider wheelColliderRightBack;
    public WheelCollider wheelColliderLeftBack;

    public Transform wheelRightFront;
    public Transform wheelLeftFront;
    public Transform wheelRightBack;
    public Transform wheelLeftBack;

    public float motorTorque = 100f;
    public float maxSteer = 20f;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
        joystick = FindObjectOfType<FixedJoystick>();
    }

    private void FixedUpdate()
    {
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            wheelColliderRightBack.motorTorque = joystick.Vertical * motorTorque;
            wheelColliderLeftBack.motorTorque = joystick.Vertical * motorTorque;
            wheelColliderLeftFront.steerAngle = joystick.Horizontal * maxSteer;
            wheelColliderRightFront.steerAngle = joystick.Horizontal * maxSteer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Vector3.zero;
        var rot = Quaternion.identity;

        wheelColliderLeftBack.GetWorldPose(out pos, out rot);
        wheelLeftBack.position = pos;
        wheelLeftBack.rotation = rot * Quaternion.Euler(0, 0, 0);

        wheelColliderRightBack.GetWorldPose(out pos, out rot);
        wheelRightBack.position = pos;
        wheelRightBack.rotation = rot * Quaternion.Euler(0, 0, 0);

        wheelColliderLeftFront.GetWorldPose(out pos, out rot);
        wheelLeftFront.position = pos;
        wheelLeftFront.rotation = rot * Quaternion.Euler(0, 0, 0);

        wheelColliderRightFront.GetWorldPose(out pos, out rot);
        wheelRightFront.position = pos;
        wheelRightFront.rotation = rot * Quaternion.Euler(0, 0, 0);
    }
}
