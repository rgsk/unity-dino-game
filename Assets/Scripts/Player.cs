using UnityEngine;

public class Player : MonoBehaviour {
    private CharacterController character;
    private Vector3 direction;
    public float gravity = 9.81f * 2f;
    public float jumpForce = 8f;
    public bool walking = false;
    private void Awake() {
        character = GetComponent<CharacterController>();
    }

    private void OnEnable() {
        direction = Vector3.zero;
    }
    private void Update() {
        direction += Vector3.down * gravity * Time.deltaTime;
        if (character.isGrounded) {
            walking = true;
            direction = Vector3.down;
            if (
                Input.GetButton("Jump") ||
                Input.GetKey(KeyCode.UpArrow) ||
                Input.GetKey(KeyCode.W)
              ) {
                walking = false;
                direction = Vector3.up * jumpForce;
            }
        }
        character.Move(direction * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Obstacle")) {
            GameManger.Instance.GameOver();
        }
    }
}
