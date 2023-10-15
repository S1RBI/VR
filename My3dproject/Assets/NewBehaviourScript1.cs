using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript1 : MonoBehaviour
{
    public Text scoreText;
    public int initialScore = 10;
    public float moveSpeed = 5.0f;

    private int score;
    private Rigidbody rb;
    private bool isMoving = true;

    private void Start()
    {
        score = initialScore;
        rb = GetComponent<Rigidbody>();
        UpdateScoreText();
    }

    private void Update()
    {
        if (isMoving)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
            rb.velocity = movement * moveSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetScore();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OtherObjectTag"))
        {
            score--;
            UpdateScoreText();

            if (score <= 0)
            {
                isMoving = false;
            }
        }
    }

    private void ResetScore()
    {
        score = initialScore;
        UpdateScoreText();
        isMoving = true;
    }
}
