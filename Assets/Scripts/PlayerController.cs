using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform shootPosition;
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip coinGatherSound;
    AudioSource playerAudio;
    Animator animator;
    float jumpingTimer = 0;
    bool isGrounded = true;
    float shootFrequency = 0.3f;
    float shootTimer;
    Rigidbody2D rb;
    SpriteRenderer playerSprite;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        MovePlayer();
        shootTimer += Time.deltaTime;
        jumpingTimer += Time.deltaTime;
        Shoot();
    }

    public void MovePlayer()
    {
        if (Input.GetButton("Vertical") && isGrounded)
        {
            Jump();
        }
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if(horizontalInput < 0)
        {
            playerSprite.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            playerSprite.flipX = false;
        }
        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);
        animator.SetFloat("Move_Speed", Mathf.Abs(horizontalInput));
    }

    public void Jump()
    {
        if (jumpingTimer >= 0.7f)
        {
            playerAudio.PlayOneShot(jumpSound, 0.5f);
            rb.velocity = new Vector2(0, jumpPower);
            isGrounded = false;
            animator.SetBool("Is_Jumping", true);
            jumpingTimer = 0f;
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("Is_Jumping", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            playerAudio.PlayOneShot(coinGatherSound, 0.5f);
        }
    }
    void Shoot()
    {

        
        if (Input.GetButton("Space") && shootTimer >= shootFrequency)
        {
            animator.SetBool("Is_Shooting", true);
            Instantiate(projectile, shootPosition.position, shootPosition.rotation);
            shootTimer = 0;
            playerAudio.PlayOneShot(shootSound, 0.5f);
        }
        else
        {
            animator.SetBool("Is_Shooting", false);
        }
    }
}
