using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BouncyBall : MonoBehaviour
{
    public float minHight = -5.5f;
    public float maxVelocity = 15f;

    Rigidbody2D rb;

    int score = 0;
    int lives = 5;

    public TextMeshProUGUI scoreTxt;
    public GameObject[] livesImage;

    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < minHight)
        {
            // check the lives of player
            if(lives <= 0)
            {
                GameOver();
            }
            else
            {
                // set the position anh velocity of the ball by default
                transform.position = Vector3.zero;
                rb.velocity = Vector3.zero;
                lives--;
                livesImage[lives].SetActive(false);
            }
        }

        if(rb.velocity.magnitude > maxVelocity)
        {
            // ?
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            Debug.Log("destroy brick");
            score += 10;
            scoreTxt.text = score.ToString("00000");
        }
    }
    
    void GameOver()
    {
        Debug.Log("Game Over");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
}
