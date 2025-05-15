using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text scoreText;
    public GameObject winPanel;
    public GameObject failPanel; 

    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    private int score = 0;
    private bool isGameOver = false; 

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        winPanel.SetActive(false);
        if (failPanel != null)
            failPanel.SetActive(false);

        UpdateScoreUI();
        InvokeRepeating("SpawnEnemy", 2f, 3f);
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        UpdateScoreUI();

        if (score >= 100)
        {
            WinGame();
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    void WinGame()
    {
        isGameOver = true;
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameOver() 
    {
        if (isGameOver) return;

        isGameOver = true;
        Debug.Log("Game Over");
        if (failPanel != null)
            failPanel.SetActive(true);

        Time.timeScale = 0;
    }

    void SpawnEnemy()
    {
        if (isGameOver) return;

        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[index].position, Quaternion.identity);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
