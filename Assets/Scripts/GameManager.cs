using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isAlive;
    public int score = 0;
    Animator animator;

    private void Start()
    {
        animator = GameObject.Find("Player").GetComponent<Animator>();
    }

    public void IncreaseScore(int val)
    {
        score += val;
    }

    public void PlayerDeath()
    {
        isAlive = false;
        animator.SetBool("Is_Alive", false);       
        Invoke("GameOver", 2f);
    }
    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDeath();
    }
}
