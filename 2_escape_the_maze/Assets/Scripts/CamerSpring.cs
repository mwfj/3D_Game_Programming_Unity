using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerSpring : MonoBehaviour
{
    public GameObject target;
    // private Matrix4x4 cameraMatrix;

    // Horizontal and Vertical following distance
    public float hDist, vDist;
    //Higher value means stiffer spring and closer to target
    public float springConst;

    public float dampConst;

    // The actual postion that the camera located        
    private Vector3 actualPos;
    // the speed the camera move from idea positon to actual position
    public Vector3 velocity;

    // ------------------------------------

    // Calculate rotation of camera for each frame
    Quaternion targetRotation;

    public float turnSpeed;
    // Calculate the forward direction and up direction for camera
    void ComputeMatrix(){
        Vector3 cameraF = target.transform.position - actualPos;
        cameraF.Normalize();

        Vector3 cameraUP = Vector3.Cross(cameraF, -(transform.right) );
        cameraUP.Normalize();
        // transform.LookAt(actualPos, cameraUP);

    }

    // Camera rotating based on the character moving direction and position.
    void RotateAroundTarget(){
        targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
    // Start is called before the first frame update
    // Initialize all the variable and calculate actual postion for the first time
    void Start()
    {
        hDist = 8.0f;
        vDist = 4.0f;
        turnSpeed = 10.0f;

        springConst = 20.0f;
        dampConst = 2.0f * Mathf.Sqrt(springConst);

        actualPos = target.transform.position - target.transform.forward*hDist +target.transform.up*vDist;
        velocity = Vector3.zero;
        transform.position = actualPos;
        ComputeMatrix();
        transform.LookAt(target.transform.position, actualPos);
    }
    

    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    // After updating for the each frame, calulate the ideal position for the camera based on the character's position and direction
    // Then calculate the actual position
    void LateUpdate()
    {
        Vector3 idealPos = target.transform.position - target.transform.forward*hDist + target.transform.up*vDist;

        Vector3 displacement = actualPos - idealPos;

        Vector3 springAccel = (-springConst*displacement) - (dampConst*velocity);

        velocity += springAccel * Time.deltaTime;

        actualPos += velocity * Time.deltaTime;

        transform.position = actualPos;
        // transform.LookAt(target.transform.position, actualPos);
        ComputeMatrix();
        RotateAroundTarget();
    }
}
