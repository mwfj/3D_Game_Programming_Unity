using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    // The Arm object(First Joint)
    public GameObject Joint1;
    //the Joint1 object(Second Object)
    public GameObject Joint2;
    //The Joint2 object(Third Object)

    //The Crane Object
    public GameObject Crane;

    public float smooth = 15.0f;
    public float tiltAngle = 120.0f;

    // The angle for Joint1
    // public float Joint1Angle;
    // The angle for Joint2
    // public float Joint2Angle;

    // The link between Arm and Joint1
    public GameObject Link1;
    // The link between Joint1 and Joint2
    public GameObject Link2;
    // Record the length of Link1
    // Matrix4x4 Joint1RotationMat;

    // Start is called before the first frame update
    void Start()
    {
        // 15 degrees
        // Joint1Angle = 15;
        // 60 degrees
        // Joint2Angle = 60;
        // matrix[0][0] = 1;
        // transform.rotation
        // Debug.Log(Mathf.Sin((60*Mathf.PI)/180));
        // Rotation around X-axis for Joint1
        // Joint1RotationMat = Matrix4x4.identity;                                                 // 1   0   0   0
        // Joint1RotationMat.m11=Joint1RotationMat.m22 = Mathf.Cos( (Joint1Angle*Mathf.PI)/180 );  // 0  cos -sin 0
        // Joint1RotationMat.m21 = Mathf.Sin( (Joint1Angle*Mathf.PI)/180 );                        // 0  sin  cos 0
        // Joint1RotationMat.m12 = -Joint1RotationMat.m21;                                         // 0   0   0   1

    }
    // Update is called once per frame
    void Update()
    {  
        // Rotate the crane body to left by y axis
        if(Input.GetKey(KeyCode.J)){
            // Quaternion rotation_left = Quaternion.Euler(0.0f,-tiltAngle,0.0f);
            // transform.rotation = Quaternion.Slerp(transform.rotation, rotation_left,Time.deltaTime);
            transform.Rotate(Vector3.up,-tiltAngle*Time.deltaTime);
        }
        // Rotate the crane body to right by y axis
        if(Input.GetKey(KeyCode.K)){
            transform.Rotate(Vector3.up,tiltAngle*Time.deltaTime);
        }
        // Move the crane forward
        if(Input.GetKey(KeyCode.W)){
            Crane.transform.position += Vector3.forward*smooth*Time.deltaTime;
        }
        // Move the crane back
        if(Input.GetKey(KeyCode.S)){
            Crane.transform.position += Vector3.back*smooth*Time.deltaTime;
        }
        // Move the crane left
        if(Input.GetKey(KeyCode.A)){
            Crane.transform.position += Vector3.left*smooth*Time.deltaTime;
        }
        // Move the crane right
        if(Input.GetKey(KeyCode.D)){
            Crane.transform.position += Vector3.right*smooth*Time.deltaTime;
            
        }
        // When pressing the N key, restore the arm position
        if(Input.GetKey(KeyCode.N)){

            // Vector4 pos_matrix = new Vector4(
            //         Joint1.transform.position.x,
            //         Joint1.transform.position.y,
            //         Joint1.transform.position.z
            //         1
            // );
            Matrix4x4 Joint1_rotation_mat = Matrix4x4.Rotate(Joint1.transform.localRotation);
            Matrix4x4 Joint2_rotation_mat = Matrix4x4.Rotate(Joint1.transform.localRotation);
            Matrix4x4 Link1_trans_mat = Matrix4x4.Translate(Link1.transform.position*Link1.transform.localScale.x);
            Matrix4x4 Link2_trans_mat = Matrix4x4.Translate(Link2.transform.position*Link2.transform.localScale.y);
            Joint1.transform.localEulerAngles = Joint1_rotation_mat.MultiplyVector(new Vector3(60.0f,0.0f,0.0f));
            Matrix4x4 trans_mat = Joint1_rotation_mat*Link1_trans_mat*Joint2_rotation_mat*Link2_trans_mat;
            // Debug.Log(trans_mat);
            // Joint2.transform.localEulerAngles = trans_mat.MultiplyVector(new Vector3(60.0f,-23.5f,-180.5f));
            Joint2.transform.localEulerAngles = trans_mat.MultiplyVector(new Vector3(90.0f,-13f,-196f));
            // Joint2.transform.localEulerAngles = new Vector3(-60,trans_mat.m12,90);
        }
        // When pressing the M key, do the forward kinematic by matrix transfermation for arm
        if(Input.GetKey(KeyCode.M)){
            Matrix4x4 Joint1_rotation_mat = Matrix4x4.Rotate(Joint1.transform.localRotation).inverse;
            Matrix4x4 Joint2_rotation_mat = Matrix4x4.Rotate(Joint1.transform.localRotation).inverse;
            Matrix4x4 Link1_trans_mat = Matrix4x4.Translate(Link1.transform.position).inverse;
            Matrix4x4 Link2_trans_mat = Matrix4x4.Translate(Link2.transform.position).inverse;
            Joint1.transform.localEulerAngles = Joint1_rotation_mat.MultiplyVector(new Vector3(0.0f,0.0f,0.0f));
            Matrix4x4 trans_mat = Joint1_rotation_mat*Link1_trans_mat*Joint2_rotation_mat*Link2_trans_mat;
            Joint2.transform.localEulerAngles = trans_mat.MultiplyVector(new Vector3(-120.0f,0.0f,90.0f));
        }
    }
}
