using UnityEngine;

public class Brick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // deletes the game object at the end of the current frame!
        Destroy(gameObject);
    }
}
