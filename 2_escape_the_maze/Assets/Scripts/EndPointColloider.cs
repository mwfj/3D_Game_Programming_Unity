using UnityEngine;
using UnityEngine.UI;

public class EndPointColloider : MonoBehaviour
{
    public Text winText;
    public Text quitGameText;
    public GameObject hiddenEdge;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        winText.text = "";
        quitGameText.text = "";
        hiddenEdge.SetActive(false);
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            hiddenEdge.SetActive(true);
            winText.text = "Congratulations! You escape the Maze!!";
            quitGameText.text = "Press ESC key to Quit the Game";
        }
    }
}
