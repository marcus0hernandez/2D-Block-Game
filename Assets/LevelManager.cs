using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// One of these sits in every level scene. It checks whether every goal
// has a block on it and then loads the next scene.
public class LevelManager : MonoBehaviour
{
    public static bool levelWon; // the player reads this to stop moving after a win
    static bool gameBeaten;      // true after the last level is finished

    public Text levelText;
    public Color blockColor = Color.white;
    public Color blockOnGoalColor = new Color(0.45f, 1f, 0.5f);  // green when on a goal
    public float nextLevelDelay = 1f;

    Goal[] goals;
    PushBlock[] blocks;

    void Start()
    {
        levelWon = false;
        gameBeaten = false;
        goals = FindObjectsByType<Goal>(FindObjectsSortMode.None);
        blocks = FindObjectsByType<PushBlock>(FindObjectsSortMode.None);

        ShowText(SceneManager.GetActiveScene().name + "\n<size=28>Arrows/WASD move   R restart</size>");
    }

    void Update()
    {
        
        // User presses space bar to start the game
        // or to skip to desired level
        if (GameInput.spacePressed())
        {
            NextLevel();
        } 

        // User presses r to restart
        if (GameInput.RestartPressed())
        {
            // Restart this level, or go back to the first one after beating the game
            SceneManager.LoadScene(gameBeaten ? 0 : SceneManager.GetActiveScene().buildIndex);
            return;
        }

        if (levelWon) return;

        // Color every block normally then color the ones on goals green
        foreach (PushBlock block in blocks) block.SetColor(blockColor);

        bool allGoalsFilled = true;
        foreach (Goal goal in goals)
        {
            PushBlock block = goal.GetBlock();
            if (block != null) block.SetColor(blockOnGoalColor);
            else allGoalsFilled = false;
        }

        if (allGoalsFilled && goals.Length > 0)
        {
            levelWon = true;
            ShowText("Level complete!");
            Invoke(nameof(NextLevel), nextLevelDelay);
        }
    }

    void NextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(next);
        }
        else
        {
            gameBeaten = true;
            ShowText("Game over!\nPress R to play again");
        }
    }

    void ShowText(string text)
    {
        if (levelText != null) levelText.text = text;
    }
}
