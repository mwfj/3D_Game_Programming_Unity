using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndThrow : MonoBehaviour
{
    // The last joint
    public GameObject parent;
    // The sign to mark whether Joint need to hold the pick up
    bool isHolding; 
    float distance;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        isHolding = false; 
    }
    // Update is called once per frame
    void Update()
    {
        // The distance between the last joint and the pickup target
        distance  = Vector3.Distance(parent.transform.position, transform.position);
        // Debug.Log(distance);
        // If the distance between the last Joint and the target less than 0.5, when press Space key, the joint will pick up the target
        // If the last joint has already holding the pickup target, then press the Space key again, the joint will release the target
        if(Input.GetKeyDown(KeyCode.Space)){
            if(isHolding){
                isHolding = false;
            }else if(!isHolding && distance<0.5f){
                isHolding = true;
            }
        }
        if(isHolding){
            // If the ball is holding, disable the gravitity and boxcollider
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = parent.transform.position;
            this.transform.parent = parent.transform;
        }else{
            // When releasing the pickup target, the gravitity and boxcollider will restore their property
            this.transform.parent = null;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
