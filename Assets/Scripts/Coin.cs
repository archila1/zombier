using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    GameManager score;

    private void Start()
    {
        score = FindObjectOfType<GameManager>();
        score.score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            score.score++;
            Destroy(gameObject);
        }
    }
}
