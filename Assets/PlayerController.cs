using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;

    private float verticalInput;
    private float horizontalInput;

    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        animator.SetFloat("left - right", horizontalInput); animator.SetFloat("up - down", verticalInput);
    }


    private void FixedUpdate()
    {

        rb.velocity = (Vector2.up * verticalInput + Vector2.right * horizontalInput).normalized * movementSpeed;

    }
}

