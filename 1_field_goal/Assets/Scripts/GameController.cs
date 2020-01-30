using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public BallController ballController;
    //Recording the duration of the game
    public float resetTimer;
    // Start is called before the first frame update
    void Start()
    {
        resetTimer = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        // After pressing Q key, quit the game
        if(Input.GetKeyDown(KeyCode.Q)){
            PlayerPrefs.SetInt("score",0);
            Application.Quit();
        }
        // After resetTime running out, the Scene will reset
        if (ballController.holding == false)
        {
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
