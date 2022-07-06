using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] AudioClip zombieSounds;
    GameObject player;
    public int enemyLife = 4;
    public float distance;
    public float enemySpeed;
    public float attackTimer;
    public float hitDistance;
    public float loiterSpeed;
    float attackTimerCountdown;
    Animator enemyAnimator;
    SpriteRenderer enemySprite;
    GameManager gameManager;
    Vector2 currentPos;
    AudioSource zombieAudioSource;


    void Awake()
    {
        //zombieAudioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        enemyAnimator = GetComponent<Animator>();
        enemySprite = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        currentPos = transform.position;
    }

    void Update()
    {
        
        EnemyAttack();
        if(Vector2.Distance(transform.position, player.transform.position) < distance)
        {
            EnemyMovement();
            //PlayZombieSound();
        }
        else
        {
            enemyAnimator.SetFloat("Enemy_Move_Speed", 0);
            //EnemyLoiter();
        }
    }

    private void EnemyLoiter()
    {
        if (transform.position.x != currentPos.x + 1)
        {
            enemyAnimator.SetFloat("Enemy_Move_Speed", 1);
            while (transform.position.x < currentPos.x + 1)
            {
                transform.Translate(Vector3.right * Time.deltaTime * loiterSpeed);
            }
            
        }

        
    }
    private void EnemyMovement()
    {       
            if (transform.position.x > player.transform.position.x)
            {
                enemySprite.flipX = true;
            }
            else
            {
                enemySprite.flipX = false;
            }
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
            enemyAnimator.SetFloat("Enemy_Move_Speed", 1);
    }

    private void EnemyAttack()
    {
        
        if (Vector2.Distance(transform.position, player.transform.position) <= hitDistance)
        {
            attackTimerCountdown += Time.deltaTime;
            if (attackTimerCountdown >= attackTimer)
            {
                enemyAnimator.SetBool("Enemy_Is_Attacking",true);
                attackTimerCountdown = 0f;
                if (Vector2.Distance(transform.position, player.transform.position) <= hitDistance)
                {
                    gameManager.PlayerDeath();
                }
            }

        }
        else
        {
            enemyAnimator.SetBool("Enemy_Is_Attacking", false);
        }


    }


    private void PlayZombieSound()
    {
        zombieAudioSource.PlayOneShot(zombieSounds, 0.4f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            if(enemyLife == 1)
            {
                enemyAnimator.SetBool("Enemy_Is_Alive", false);
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                gameObject.GetComponent<Collider2D>().enabled = false;
                gameManager.IncreaseScore(5);
                Invoke("DestroyCorpse", 2f);
                gameObject.GetComponent<EnemyScript>().enabled = false;
            }
            else
            {
                enemyLife--;
            }
        }
    }

    private void DestroyCorpse()
    {
        Destroy(gameObject);
    }
}
