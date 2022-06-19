using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody2D rb;
    float pojectileLiveCiyle = 2f;
    float destroyProjectile = 0;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;       
    }

    private void Update()
    {
        destroyProjectile += Time.deltaTime;
        if(destroyProjectile >= pojectileLiveCiyle)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
