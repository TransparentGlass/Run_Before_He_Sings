using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject startMenu;    // Start menu panel
    [SerializeField] private GameObject gameOverMenu; // Game over panel
    [SerializeField] private PlayerControl playerComponent; // score
    [SerializeField] private TextMeshProUGUI scoreText; // score

    private int highScore = 0;
    private float currentScore = 0;

    private bool isGameOver = false;
    private bool gameStarted = false;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
    }
    void Start()
    {
        // Show Start Menu at the beginning
        if (startMenu != null)
            startMenu.SetActive(true);

        if (gameOverMenu != null)
            gameOverMenu.SetActive(false);

        Time.timeScale = 0f; // pause the game until started
    }

    private void Update()
    {
        currentScore += playerComponent.speed * Time.deltaTime;

        if (currentScore > highScore) {
            highScore = Mathf.RoundToInt(currentScore);
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        UpdateScoreGUI();
    }

    public void StartGame()
    {
        gameStarted = true;

        if (startMenu != null)
            startMenu.SetActive(false);

        Time.timeScale = 1f; // resume the game
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        Time.timeScale = 0f;

        if (gameOverMenu != null)
            gameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game"); // This will show in the Editor
        Application.Quit();     // Actually quits the built game
    }

    private void UpdateScoreGUI()
    {
        scoreText.SetText($"HIGHSCORE {highScore:D5} {Mathf.RoundToInt(currentScore):D5}");
    }
}
