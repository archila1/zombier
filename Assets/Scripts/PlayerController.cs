using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;
    [SerializeField] GameObject projectile;
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
    }

    private void FixedUpdate()
    {
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
        var groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 0.7f);
        if( groundCheck.collider != null && groundCheck.collider.CompareTag("Ground"));
        {
            isGrounded = true;
        }
    }

    void Shoot()
    {
        shootTimer += Time.deltaTime;

        if (Input.GetButton("Jump") && shootTimer >= shootFrequency)
        {
            
        }
    }
}
