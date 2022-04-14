using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb2d;

    public GameObject GameWonPanel;

    public GameObject PauseMenuPanel;

    private bool isGameWon = false;

    private bool isPaused = false;

    public float speed;
    
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseMenuPanel.SetActive(true);
            isPaused = true;
        }

        Move();
    }

    private void Move()
    {
        if (isGameWon || isPaused) { return; }

        if (Input.GetAxis("Horizontal") > 0)
        {
            rb2d.velocity = new Vector2(speed, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb2d.velocity = new Vector2(-speed, 0f);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            GameWonPanel.SetActive(true);
            isGameWon = true;

            //Debug.Log("Level Won!!");
        }
        
    }
}
