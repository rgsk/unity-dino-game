using UnityEngine;

public class AnimatedSprite : MonoBehaviour {
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private int frame;
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable() {
        // we don't call Animate() directly
        // because we want to ensure GameManger.Instance.gameSpeed
        // is assigned a value in Start() of GameManager
        // and gameSpeed is not 0
        Invoke(nameof(Animate), 0f);
    }
    private void OnDisable() {
        CancelInvoke();
    }
    private void Animate() {
        frame++;
        if (frame >= sprites.Length) {
            frame = 0;
        }
        spriteRenderer.sprite = sprites[frame];
        Invoke(nameof(Animate), 1f / GameManger.Instance.gameSpeed);
    }
}
