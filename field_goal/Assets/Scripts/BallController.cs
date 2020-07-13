using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallController : MonoBehaviour
{
    private Rigidbody ball_rb;
    private Vector3 dir;
    public bool holding;
    public GameObject target;
    private Renderer re;
    // Start is called before the first frame update
    void Start()
    {
        // target_collider = target.GetComponent<Collider>();
        // ball_collider = GetComponent<Collider>();
        holding = true;
        ball_rb = GetComponent<Rigidbody>();
        ball_rb.useGravity = false;
        re = target.GetComponent<Renderer>();
    }
   

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(holding){
            dir = target.transform.position - this.transform.position;
            // dir = target.transform.position - transform.position;
            dir = dir.normalized;
        }
        // Physics.IgnoreCollision(target_collider,ball_collider);
        if(Input.GetKeyDown(KeyCode.Space)){
            holding = false;
            re.enabled = false;
        }
        
        if(!holding){
            transform.Rotate( new Vector3(30.0f,0.0f,0.0f));
            // ball_rb.AddForce(c.transform.forward*100.0f, ForceMode.Impulse);
            ball_rb.AddForce( target.transform.position + (dir *60.0f), ForceMode.Impulse);   
            ball_rb.useGravity = true;
        }

    }

}
