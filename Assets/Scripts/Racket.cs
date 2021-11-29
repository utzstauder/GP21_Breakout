using UnityEngine;

public class Racket : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    public float movementSpeed = 4f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = Vector2.right * movementSpeed * Input.GetAxisRaw("Horizontal");
    }
}
