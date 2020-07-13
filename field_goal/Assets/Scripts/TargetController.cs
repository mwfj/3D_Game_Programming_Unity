using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    // To make football run faster
    public float flying_speed;
    // The speed of football self-ratation
    public  float rotating_speed;
    // Start is called before the first frame update
    void Start()
    {
        flying_speed = 0.02f;
        rotating_speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Use keyboard to make object move
        float x_axis_value = Input.GetAxis("Horizontal");
        float y_axis_value = Input.GetAxis("Vertical");

        this.transform.Translate(
            new Vector3(
            x_axis_value*flying_speed,
            y_axis_value*flying_speed,
            0.0f
            )  
        );
        // Limit the move area
        if(this.transform.position.y < 0.0f)
        {
            Vector3 y_zero = new Vector3(x_axis_value, 0.0f, 0.0f);
            this.transform.Translate(y_zero);
        }else if(this.transform.position.x > 50.0f)
        {
            this.transform.position = new Vector3(50.0f, transform.position.y, transform.position.z);
        }else if(this.transform.position.x < -50.0f)
        {
            this.transform.position = new Vector3(-50.0f, transform.position.y, transform.position.z);
        }
    }
}
