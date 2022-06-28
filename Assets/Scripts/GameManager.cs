using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isAlive;
    public int score = 0;
    GameObject player;
    TextMeshProUGUI scoreText;

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            return;
        }
        else
        {
            player = GameObject.Find("Player");
            scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        }
        IncreaseScore(0);
    }

    public void IncreaseScore(int val)
    {
        score += val;
        scoreText.text = $"Score: {val}";
    }

    public void PlayerDeath()
    {
        isAlive = false;
        player.GetComponent<Animator>().SetBool("Is_Alive", false);       
        Invoke("GameOver", 2f);
    }
    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        else
        {
            player.GetComponent<PlayerController>().enabled = false;
            PlayerDeath();

        }
    }
}
