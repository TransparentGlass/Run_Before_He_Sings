using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject startMenu;    // Start menu panel
    [SerializeField] private GameObject gameOverMenu; // Game over panel

    private bool isGameOver = false;
    private bool gameStarted = false;

    void Start()
    {
        // Show Start Menu at the beginning
        if (startMenu != null)
            startMenu.SetActive(true);

        if (gameOverMenu != null)
            gameOverMenu.SetActive(false);

        Time.timeScale = 0f; // pause the game until started
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
}
