using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public float PlayerJump = 500.0f;
    public float playerHeight = 2.0f;
    Rigidbody2D rb;

    BoxCollider2D playerCollider;

    float startLevel;
    public float CameraFollowSpeed = 2.0f;
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x - transform.localScale.x / 2, transform.position.y - playerHeight / 2 - 0.1f),
            Vector2.right,
            1);
        return hit.transform != null;
    }

    void Start()
    {
        startLevel = transform.position.y;

        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void UpdateCameraPosition()
    {
        if (transform.position.y > Camera.main.transform.position.y)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x,
            Camera.main.transform.position.y + Time.deltaTime * CameraFollowSpeed,
            Camera.main.transform.position.z);
        }
    }

    void StopTheGame()
    {
        //TODO move to main menu
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void CheckThatPlayerIsAlive()
    {
        //Check that players y > Lowest edge of camera.
        if (transform.position.y - Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y < 0)
        {
            ScoreManager.instance.PlayerDied();
            StopTheGame();
        }

        float colliderWidth = playerCollider.size.x;

        //Check that there isn't block above the player
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x - colliderWidth / 2, transform.position.y + playerHeight / 2 + 0.1f),
           Vector2.right,
           colliderWidth);

        if (null != hit.transform)
        {
            Rigidbody2D colliderRb = hit.transform.GetComponent<Rigidbody2D>();
            if (null != colliderRb && 5 < Mathf.Abs(colliderRb.velocity.y))
            {
                //Stop the game if object have velocity
                StopTheGame();
            }
        }

        Debug.DrawRay(new Vector2(transform.position.x - colliderWidth / 2, transform.position.y + playerHeight / 2 + 0.2f), Vector2.right * colliderWidth, Color.red);
    }

    void AddScore()
	{
        ScoreManager.instance.AddPoints(System.Math.Round((transform.position.y - startLevel) * 10, 2));
    }

    void Update()
    {
        AddScore();

        UpdateCameraPosition();

        CheckThatPlayerIsAlive();

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

     
        if (0 != input.x)
        {
            transform.Translate(input.x * playerSpeed * Time.deltaTime, 0, 0);
        }

        Debug.DrawRay(new Vector2(transform.position.x - transform.localScale.x/2, transform.position.y - playerHeight/2 - 0.2f), Vector2.right * 1f, Color.red);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(new Vector2(0, PlayerJump * rb.mass));
        }
    }
}
