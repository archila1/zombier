using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    GameObject player;
    public float speed = 20f;
    Rigidbody2D rb;
    float pojectileLiveCiyle = 2f;
    float destroyProjectile = 0;
    


    void Start()
    {
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (player.GetComponent<SpriteRenderer>().flipX == false)
        {
            rb.velocity = transform.right * speed;
        }
        else
        {
            rb.velocity = transform.right * -speed;
        }
        
        
              
    }

    private void Update()
    {
        destroyProjectile += Time.deltaTime;
        if(destroyProjectile >= pojectileLiveCiyle)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
