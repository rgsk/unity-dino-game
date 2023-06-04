using UnityEngine;

public class PlayerAnimatedSprite : AnimatedSprite {

    public Player player;
    public Sprite[] jumpSprites;
    public Sprite crouchSprite;
    private bool jumpActive = false;
    private bool crouchActive = false;
    private int jumpFrame = 0;
    public Sprite[] walkingSprites;
    public Sprite[] runningSprites;
    private bool assignedRunningSprites = false;

    private void Start() {
        sprites = walkingSprites;
        assignedRunningSprites = false;
    }

    private void OnDisable() {
        sprites = walkingSprites;
        assignedRunningSprites = false;
    }


    private void Update() {
        if (
            !assignedRunningSprites &&
            GameManger.Instance.score >= 500) {
            GameManger.Instance.NextLevel();
            assignedRunningSprites = true;
            sprites = runningSprites;
        }
        if (player) {
            if (player.jumping) {
                if (!jumpActive) {
                    jumpActive = true;
                    CancelInvoke(nameof(Animate));
                    jumpFrame = 0;
                    AnimateJump();
                }
            } else if (player.crouching) {
                if (!crouchActive) {
                    crouchActive = true;
                    CancelInvoke(nameof(Animate));
                    CancelInvoke(nameof(AnimateJump));
                    spriteRenderer.sprite = crouchSprite;
                }
            } else {
                if (jumpActive) {
                    jumpActive = false;
                    CancelInvoke(nameof(AnimateJump));
                    Animate();
                }
                if (crouchActive) {
                    crouchActive = false;
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