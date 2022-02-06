using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform centerOfMass;
    public float motorTorque = 1500f;
    public float maxSteer = 20f;
    public GameObject totalWheel;
    public float Steer { get; set; }
    public float Throttle { get; set; }

    private Rigidbody _rigidbody;
    public List<Wheel> wheels = new List<Wheel>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < totalWheel.transform.childCount; i++)
        {
            wheels.Add(totalWheel.transform.GetChild(i).GetComponent<Wheel>());
        }
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Steer = GameManager.Instance.inputController.steerInput;
        Throttle = GameManager.Instance.inputController.ThrottleInput;

        for (int i = 0; i < wheels.Count; i++)
        {
            wheels[i].SteerAngle = Steer * maxSteer;
            wheels[i].Torque = Throttle * motorTorque;
        }
    }
}
