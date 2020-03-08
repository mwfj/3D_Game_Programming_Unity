using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // When Total time Runs up, the Game will end
    public float totalTime;
    // The final Text will show when time goes up
    public Text endText;
    // The final Text will show when time goes up
    public Text endInstruction;
    // Show the Remaining Time
    public Text timerDisplay;
    public Text InstrutionText;
    public Text RuleText;
    // Start is called before the first frame update
    void Start()
    {
        totalTime = 100f;
        InstrutionText.text = "Press W/A/S/D to Move Foward/Back/Left/Right \nPress J/K to Rotate Left/Right By Y Axis \nPress N/M to Put Down/Up the Arm \nPress Space to Attach/Unattch Coin\nPress Q to Quit the Game";
        endText.text = "Time is up,\n Thank you for playing this Game!";
        endInstruction.text = "Press ESC key to Quit the Game";
        RuleText.text = "Game Rule: \nPut the Green Coin into Red Wall Area to Get Score.";
        timerDisplay.text = "";
        endText.gameObject.SetActive(false);
        endInstruction.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease Game Time
        totalTime -=Time.deltaTime;
        if(totalTime<=0.0f){
            totalTime = 0.0f;
        }
        timerDisplay.text = totalTime.ToString();
        // When Game end, pause the game
        if(totalTime<=0.0f){
            Time.timeScale = 0.0f;
            endText.gameObject.SetActive(true);
            endInstruction.gameObject.SetActive(true);
        }
        //Quit the Game
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
