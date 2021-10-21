using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoistScript : MonoBehaviour
{
    [SerializeField]
    private SliderJoint2D platform;
    [SerializeField]
    private WheelJoint2D sheave; 
    private string limit;
    private bool chargeTime;

    void Start()
    {
        platform.motor = MotorChangeDirection(platform.motor);
        sheave.motor = MotorChangeDirection(sheave.motor);
    }
    void FixedUpdate()
    {
        limit = platform.limitState.ToString();
        if (limit == "Inactive")
        {
            chargeTime = true;
        }        
        if ((limit == "UpperLimit" && chargeTime) || (limit == "LowerLimit" && chargeTime))
        {            
            platform.motor = MotorChangeDirection(platform.motor);
            sheave.motor = MotorChangeDirection(sheave.motor);
            chargeTime = false;
        }
    }

    JointMotor2D MotorChangeDirection(JointMotor2D jointMotor)
    {        
            return new JointMotor2D { motorSpeed = -jointMotor.motorSpeed, maxMotorTorque = jointMotor.maxMotorTorque };     
    }   
}
