using Unity.Mathematics;
using UnityEngine;


public class VehicleMovement : MonoBehaviour
{

    // Wheel Colliders
    public WheelCollider frontRight;
    public WheelCollider frontLeft;
    public WheelCollider backRight;
    public WheelCollider backLeft;

    //Wheel Transforms
    public Transform frontRightTransform;
    public Transform frontLeftTransform;
    public Transform backRightTransform;
    public Transform backLeftTransform;

    //Motion Variables
    public float acceleration = 500f;
    public float brakingForce = 200f;
    public float maxTurnAngle = 15f;
    private float currentAcceleration = 0f;
    private float currentBrakeForce = 0f;
    private float currentTurnAngle = 0f;


    // Handling all movement using WheelCollider
    private void FixedUpdate()
    {
        // Getting forward/reverse acceleration from vertical axis (W and S keys)
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        // When Spcae is pressed apply brakingForce.
        if (Input.GetKey(KeyCode.Space))
            currentBrakeForce = brakingForce;
        else
            currentBrakeForce = 0f;

        // Apply acceleration to front wheels
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        // Apply braking force to all four wheels
        frontRight.brakeTorque = currentBrakeForce;
        frontLeft.brakeTorque = currentBrakeForce;
        backRight.brakeTorque = currentBrakeForce;
        backLeft.brakeTorque = currentBrakeForce;

        //Steering Vehicle using A and D keys.
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        // Update Wheel mesh rotation/position
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
        UpdateWheel(backRight, backRightTransform);

    }
    //Making wheel meshes move and rotate with collider movement.
    private void UpdateWheel(WheelCollider col, Transform trans)
    {
        // Get wheel collider state.
        Vector3 position;
        Quaternion rotation; //Used to track 3D rotations
        col.GetWorldPose(out position, out rotation);

        // Set wheel collider state.
        trans.position = position;
        trans.rotation = rotation;
    }
}

