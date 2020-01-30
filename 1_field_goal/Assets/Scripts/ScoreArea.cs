using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreArea : MonoBehaviour
{
    // Show the user you are hit the target area
    public Text GoalText;
    // Instruction for running the game
    public Text InstructionText1;
    public Text InstructionText2;
    public Text InstructionText3;
    // Display the current score you got
    public Text ScoreBox;
    private int count = 0;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        count = PlayerPrefs.GetInt("score");;
        GoalText.text = "";
        InstructionText1.text = "Press WASD to move aiming target";
        InstructionText2.text = "Press Space to Kick the ball";
        InstructionText3.text = "Press Q to Quit the Game";
        ScoreBox.text = "";
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        // Get the currnt count
        count = PlayerPrefs.GetInt("score");
        ScoreBox.text = "Score is:" + count.ToString();
    }
    void OnTriggerEnter(Collider other) {
        if(other.GetComponent<BallController>()!=null){

            Debug.Log("Goooooal!!!!!!");    
            GoalText.text = "Goooooal!!!";
            count++;
            // Create score for display
            PlayerPrefs.SetInt("score", count);
        }
    }
}
