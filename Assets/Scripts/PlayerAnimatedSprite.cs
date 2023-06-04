using UnityEngine;

public class PlayerAnimatedSprite : AnimatedSprite {

    public Player player;
    public Sprite idleSprite;
    private bool on = false;

    private void Update() {
        if (player) {
            if (player.spritesSwitching) {
                if (!on) {
                    on = true;
                    Animate();
                }
            } else {
                on = false;
                spriteRenderer.sprite = idleSprite;
                CancelInvoke();
            }
        }
    }

}