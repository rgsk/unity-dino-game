using UnityEngine;

public class Obstacle : MonoBehaviour {
    private float leftEdge;
    private void Start() {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }
    private void Update() {
        transform.position += Vector3.left * GameManger.Instance.gameSpeed * Time.deltaTime;
        if (transform.position.x < leftEdge - transform.localScale.x) {
            Destroy(gameObject);
        }
    }
}
