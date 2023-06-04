using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManger : MonoBehaviour {
    public static GameManger Instance { get; private set; }
    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Button retryButton;
    private Player player;
    private Spawner spawner;
    public float score;
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            DestroyImmediate(gameObject);
        }
    }
    private void OnDestroy() {
        if (Instance == this) {
            Instance = null;
        }
    }
    private void Start() {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        NewGame();

    }
    public void NewGame() {

        var obstacles = FindObjectsOfType<Obstacle>();
        foreach (var obstacle in obstacles) {
            Destroy(obstacle.gameObject);
        }

        gameSpeed = initialGameSpeed;
        enabled = true;
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        score = 0;
        UpdateHighScore();
    }

    public void NextLevel() {
        gameSpeed += gameSpeedIncrease * 10 * Time.deltaTime;
    }

    private void Update() {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }
    public void GameOver() {
        gameSpeed = 0f;
        enabled = false;
        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        UpdateHighScore();
    }
    private void UpdateHighScore() {
        float highScore = PlayerPrefs.GetFloat("highScore", 0);
        if (score > highScore) {
            highScore = score;
            PlayerPrefs.SetFloat("highScore", highScore);
        }
        highScoreText.text = Mathf.FloorToInt(highScore).ToString("D5");
    }
}
