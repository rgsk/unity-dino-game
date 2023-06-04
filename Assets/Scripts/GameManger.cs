using UnityEngine;

public class GameManger : MonoBehaviour {
    public static GameManger Instance { get; private set; }
    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }
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
        NewGame();
    }
    private void NewGame() {
        gameSpeed = initialGameSpeed;
    }
    private void Update() {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
    }
}
