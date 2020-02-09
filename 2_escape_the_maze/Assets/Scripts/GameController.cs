using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private bool showSign; 
    public Text Instruction1;
    public Text Instruction2;
    public Text Instruction3;
    public Text Instruction4;
    public Text Instruction5;
    public GameObject signObj;
    
    // Start is called before the first frame update
    void Start()
    {
        showSign = false;
        Instruction1.text = "Holding W and Press S to Move forward and back";
        Instruction2.text = "Press A and D to Move left and right";
        Instruction3.text = "Press G to open the guide Mode";
        Instruction4.text = "Press ESC to quit the game";
        Instruction5.text = "Hint, there have 20 Coin here.";
        
        
    }
    // Update is called once per frame
    void Update()
    {
        // After pressing Q key, quit the game
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
        if(Input.GetKeyDown(KeyCode.G)){
            if(showSign == true)
                showSign = false;
            else if(showSign == false)
                showSign = true;
        }
        if(showSign == true){
            signObj.SetActive(true);
        }else{
            signObj.SetActive(false);
        }
    }
}
