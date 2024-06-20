using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 0.02f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.1f;
    public AudioClip respawnSound; // Sound to play when respawning
    public Transform respawnPoint;

    private Rigidbody2D rb;
    private bool isGrounded;

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        transform.position = respawnPoint.position;
        if (respawnSound != null) // Check if the respawn sound exists
        {
            AudioSource.PlayClipAtPoint(respawnSound, transform.position); // Play the respawn sound
        }
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        float moveInput = Input.GetAxis("Horizontal");
        if (moveInput != 0)
        {
            anim.Play("Run");
        }
        else {
            anim.Play("Idle");
        }
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if ((Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded && Mathf.Abs(rb.velocity.y) <= 0.01f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.Play("Jump");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike"))
        {
            RespawnPlayer();
        }
    }

    private void RespawnPlayer()
    {
        transform.position = respawnPoint.position;
        if (respawnSound != null) // Check if the respawn sound exists
        {
            AudioSource.PlayClipAtPoint(respawnSound, transform.position); // Play the respawn sound
        }
    }
}

