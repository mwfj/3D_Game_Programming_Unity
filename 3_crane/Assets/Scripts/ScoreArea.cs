using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreArea : MonoBehaviour
{
    public int score;
    // Show the Score Point
    public Text scoreText;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        score = 0;
        scoreText.text = "Score:" + score.ToString();
    }
    void CountScore(){
        scoreText.text = "Score:" + score.ToString();
    }

    // When coin falls in target area, increase the score
    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Triggered!!");
        if(other.gameObject.CompareTag("pickup")){
            score++;
            // CountScore();
        }
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        // Debug.Log("score:"+score);
        CountScore();
    }
    
}
