using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int score = 0; // keeps track of score
    public Text scoreText; // establishes outside connection for script

    // adds 1 to the score on screen
    [ContextMenu("Update Score")]
    public void updateScore()
    {
        score += 1;
        scoreText.text = score.ToString();
    }
}