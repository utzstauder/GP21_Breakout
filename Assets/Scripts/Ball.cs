using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    private Vector3 initialPosition;

    public float initialSpeed = 20f;
    public float racketDeviationStrength = 5f;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player") == true)
        {
            float xBall = transform.position.x;
            float xRacket = collision.collider.transform.position.x;
            float xOffset = xBall - xRacket;

            float racketWidth = collision.collider.transform.localScale.x;
            float ballWidth = transform.localScale.x;
            float normalizedOffset = xOffset / ((racketWidth + ballWidth) / 2);

            Debug.Log(normalizedOffset);

            float currentSpeed = rigidbody2D.velocity.magnitude;
            
            Vector2 newDirection = rigidbody2D.velocity;

            newDirection.x += normalizedOffset * racketDeviationStrength;

            rigidbody2D.velocity = newDirection.normalized * currentSpeed;
        }
    }

    private void LaunchBall()
    {
        rigidbody2D.velocity = Vector2.up * initialSpeed;
    }
}
