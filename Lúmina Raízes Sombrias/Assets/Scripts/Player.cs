using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;        // Velocidade de movimento
    public float jumpForce = 8f;    // For�a do pulo
    private bool isGrounded;        // Verifica se o player est� no ch�o
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal"); // A/D ou setas
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Inverte sprite conforme dire��o
        if (move > 0) transform.localScale = new Vector3(1, 1, 1);
        if (move < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    // Detecta colis�o com o ch�o
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
            isGrounded = true;
    }
}
