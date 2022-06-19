using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform shootPosition;


    bool isGrounded = true;
    float shootFrequency = 0.3f;
    float shootTimer;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        shootTimer += Time.deltaTime;
        Shoot();
    }

    public void MovePlayer()
    {
        if (Input.GetButton("Vertical") && isGrounded)
        {
            Jump();
        }
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);
    }

    public void Jump()
    {
        rb.velocity = new Vector2(0, jumpPower);
        isGrounded = false;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void Shoot()
    {
        

        if (Input.GetButton("Space") && shootTimer >= shootFrequency)
        {
            Instantiate(projectile, shootPosition.position, shootPosition.rotation);
            shootTimer = 0;
        }
    }
}
