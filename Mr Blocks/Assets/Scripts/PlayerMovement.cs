using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb2d;

    public SpriteRenderer FlipX;

    public GameObject GameWonPanel;

    public GameObject GameOverPanel;

    public GameObject PauseMenuPanel;

    private bool isGameOver = false;

    private bool isPaused = false;

    public float speed = 5;
    
    

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseMenuPanel.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
        }

        Move();
    }

    public void ResumeGame()
    {
        PauseMenuPanel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Move()
    {
        if (isGameOver || isPaused) { return; }

        if (Input.GetAxis("Horizontal") > 0)
        {
            rb2d.velocity = new Vector2(speed, 0f);
            FlipX.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb2d.velocity = new Vector2(-speed, 0f);
            FlipX.flipX = true;
            
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rb2d.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb2d.velocity = new Vector2(0f, -speed);
        }
        else if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            rb2d.velocity = new Vector2(0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            GameWonPanel.SetActive(true);
            isGameOver = true;
            Debug.Log("Level Complete!!");
        }

        else if (other.CompareTag("Enemy"))
        {
            GameOverPanel.SetActive(true);
            isGameOver = true;
            Debug.Log("Level Lost!!");
        }
    }



    public void QuitGame()
    {
        Application.Quit();
    }
}
