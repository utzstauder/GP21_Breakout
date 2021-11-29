using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    private Vector3 initialPosition;

    public float initialSpeed = 20f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        initialPosition = transform.position;
    }

    void Start()
    {
        LaunchBall();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rigidbody2D.position = initialPosition;

        LaunchBall();
    }

    private void LaunchBall()
    {
        rigidbody2D.velocity = Vector2.up * initialSpeed;
    }
}
