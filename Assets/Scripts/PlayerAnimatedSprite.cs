using UnityEngine;

public class PlayerAnimatedSprite : AnimatedSprite {

    public Player player;
    public Sprite[] jumpSprites;
    private bool jumpActive = false;
    private int jumpFrame = 0;

    private void Update() {
        if (player) {
            if (player.jumping) {
                if (!jumpActive) {
                    jumpActive = true;
                    CancelInvoke(nameof(Animate));
                    jumpFrame = 0;
                    AnimateJump();
                }
            } else {
                if (jumpActive) {
                    jumpActive = false;
                    CancelInvoke(nameof(AnimateJump));
                    Animate();
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