using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // The moving speed of character
    public float speed;
    // The turning speed when character change the direction
    public float turnSpeed;
    // The text to show how many coin the user currently collect
    public Text scoreText;

    // When the user collect all the coin(20) in this game, this text will show on the screen
    public Text challengeText;

    //Count the number of coin the user collect
    private int countScore = 0;
    // The main camera
    private Transform c;

    // Used for moving control and calculate the direction
    Vector2 dirInput;
    // The angle each change for every turn
    public float turnAngle;
    // The Quaternion variable for present the total rotation
    Quaternion targetRotation;
    // Start is called before the first frame update
    // Initialize variable
    void Start()
    {
        speed = 15.0f;
        turnSpeed = 10.0f;
        // moveDirection = (Input.mousePosition-transform.position).normalized;
        c = Camera.main.transform;
        scoreText.text = "";
        challengeText.text = "";
    }
    // Show the current score the user got in real time
    void CountScore(){
        scoreText.text = "Score:" + countScore.ToString();
        if(countScore >= 20){
            challengeText.text = "Yeahhhhhh, you complete the challenge";
        }
    }
    // Make keyboard control the movement of character
    void GetInput(){
        dirInput.x = Input.GetAxisRaw("Horizontal");
        dirInput.y = Input.GetAxisRaw("Vertical");
    }
    // Calulate the anlge in each turn based on charater movement message
    void GetDirection(){
        turnAngle = Mathf.Atan2(dirInput.x,dirInput.y);
        turnAngle = Mathf.Rad2Deg*turnAngle;
        turnAngle += c.eulerAngles.y;
    }
    // Calculate the final direction based on angle calculate by GetDirection() and the axis input from keyboard
    void RotateObj(){
        targetRotation = Quaternion.Euler(0.0f, turnAngle, 0.0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    // Calculate the final move position based on turning direction and moving position
    void MoveObj(){
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>

    // When the character collides with coins, the coins disappear and the score adds one.
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collector")){
            other.gameObject.SetActive(false);
            countScore++;
            CountScore();
        }
    }
    // Calulate all the operation above in each frame
    void Update()
    {
        GetInput();
        if(Mathf.Abs(dirInput.x)<1 && Mathf.Abs(dirInput.y)<1) return;
        GetDirection();
        RotateObj();
        MoveObj();
        CountScore();
    }
}
