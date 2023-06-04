using UnityEngine;

public class PlayerAnimatedSprite : AnimatedSprite {

    public Player player;
    public Sprite[] jumpSprites;
    private bool walking = false;
    private int jumpFrame = 0;
    private float startOfJump;

    private void Update() {
        if (player) {
            if (player.walking) {
                if (!walking) {
                    walking = true;
                    CancelInvoke(nameof(AnimateJump));
                    Animate();
                }
            } else {
                if (walking) {
                    walking = false;
                    CancelInvoke(nameof(Animate));
                    jumpFrame = 0;
                    AnimateJump();
                }
            }
        }
    }

    public void AnimateJump() {
        jumpFrame++;
        if (jumpFrame >= jumpSprites.Length) {
            jumpFrame = 0;
        }
        spriteRenderer.sprite = jumpSprites[jumpFrame];
        Invoke(nameof(AnimateJump), 0.82f / jumpSprites.Length);
    }

}