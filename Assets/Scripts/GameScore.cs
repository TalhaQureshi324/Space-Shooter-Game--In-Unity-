using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    Text scoreText;  // UI Text component for the in-game score
    int userScore;   // Current score
    public TMP_Text finalScoreText;  // Final score display on Game Over screen
    public TMP_Text highScoreText;  // High score display on Game Over screen

    public int Score
    {
        get { return this.userScore; }
        set
        {
            this.userScore = value;
            UpdateScoreTextUI();
        }
    }
    void Start()
    {
        // Get Text UI Component of this gameobject 
        scoreText = GetComponent<Text>();
    }
    // Update the score display in the UI during gameplay
    public void UpdateScoreTextUI()
    {
        scoreText.text = $"Score: {userScore:0000}";
    }
    // Update the high score and display it on the Game Over screen
    public void HighScoreUpdate()
    {
        int savedHighScore = PlayerPrefs.GetInt("SavedHighScore", 0);
        if (userScore > savedHighScore)
        {
            PlayerPrefs.SetInt("SavedHighScore", userScore);
            savedHighScore = userScore;
        }
        // Update final score and high score texts
        finalScoreText.text = $"Final Score: {userScore}";
        highScoreText.text = $"High Score: {savedHighScore}";
    }
}