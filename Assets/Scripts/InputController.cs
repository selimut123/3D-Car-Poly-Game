using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    FixedJoystick joystick;

    public float ThrottleInput { get; private set; }
    public float steerInput { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        steerInput = joystick.Horizontal;
        ThrottleInput = joystick.Vertical;
        Debug.Log(joystick.Vertical);
    }
}
