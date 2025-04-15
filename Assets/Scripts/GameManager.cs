using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Game objects
    public GameObject playButton;
    public GameObject airplane;
    public GameObject enemySpawner;
    public GameObject gameOverSprite;  // GameOver UI
    public GameObject userScore;      // Score UI
    public GameObject gameTimer;      // Timer UI
    public GameObject gameTitle;      // Title UI

    public GameScore gameScore;       // Reference to the GameScore script

    public GameObject highScoreUI;
    public GameObject finalScoreUI;
    public enum GameStates
    {
        Opening,
        GamePlay,
        GameOver
    }

    GameStates gameStates;

    void UpdateGameStates()
    {
        switch (gameStates)
        {
            case GameStates.GameOver:
                // Stop game elements
                gameTimer.GetComponent<TimeCounter>().stopTimeCounter();
                enemySpawner.GetComponent<EnemySpawner>().StopEnemySpawn();

                highScoreUI.gameObject.SetActive(true);
                finalScoreUI.gameObject.SetActive(true);
                // Update high score on Game Over
                gameScore.HighScoreUpdate();

                // Display Game Over UI
                gameOverSprite.SetActive(true);

                // Reset to opening state after a delay
                Invoke("SetGameStateToOpening", 8f);
                break;

            case GameStates.GamePlay:
                // Reset score and hide initial UI
                gameScore.Score = 0;
                playButton.SetActive(false);
                gameTitle.SetActive(false);

                highScoreUI.gameObject.SetActive(false);
                finalScoreUI.SetActive(false);
                // Activate player and start game elements
                airplane.GetComponent<UserControll>().Init();
                enemySpawner.GetComponent<EnemySpawner>().StartEnemySpawn();
                gameTimer.GetComponent<TimeCounter>().startTimeCounter();
                break;

            case GameStates.Opening:
                // Reset UI
                gameOverSprite.SetActive(false);
                playButton.SetActive(true);
                gameTitle.SetActive(true);
                break;
        }
    }

    public void SetGameState(GameStates state)
    {
        gameStates = state;
        UpdateGameStates();
    }

    public void StartGamePlay()
    {
        SetGameState(GameStates.GamePlay);
    }

    public void SetGameStateToOpening()
    {
        SetGameState(GameStates.Opening);
    }
}