using UnityEngine;

public class Brick : MonoBehaviour
{
    BrickManager brickManager;

    public void SetBrickManager(BrickManager brickManager)
    {
        if (brickManager == null) return;
        this.brickManager = brickManager;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // notify brick manager
        brickManager.OnBeforeBrickDestroy(this);

        // deletes the game object at the end of the current frame!
        Destroy(gameObject);
    }
}
