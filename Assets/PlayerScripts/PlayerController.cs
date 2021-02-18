using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private GameObject reflectedLaser;
    private float verticalInput;
    private float horizontalInput;
    private Vector3 playerPosition;
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private Animator animator;
    [SerializeField] private PortalConnect portalPink;
    [SerializeField] private PortalConnect portalGreen;
    SpriteRenderer spriteR;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] private LayerMask laserConnect;

    bool up;
    bool down;
    bool right;
    bool left;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        animator.SetFloat("left - right", horizontalInput); animator.SetFloat("up - down", verticalInput);
    }


    private void FixedUpdate()
    {
        playerPosition = transform.position;
        rb.velocity = (Vector2.up * verticalInput + Vector2.right * horizontalInput).normalized * movementSpeed;

    }

    public Vector2 playerDirection()
    {
        Vector2 direction = Vector2.zero;
        float help = Input.GetAxisRaw("Vertical") + Input.GetAxisRaw("Horizontal");
        if ((rb.velocity.y > 0 && (rb.velocity.x > -0.5 && rb.velocity.x < 0.5)) || up)
        {
            up = true;
            direction = new Vector3(0,0,0);
            down = false;
            right = false;
            left = false;
        }
        if ((rb.velocity.y < 0 && (rb.velocity.x > -0.5 && rb.velocity.x < 0.5)) || down)
        {
            down = true;
            direction = new Vector3(0, 0, 0);
            up = false;
            right = false;
            left = false;
        }
        if ((rb.velocity.x > 0 && (rb.velocity.y > -0.5 && rb.velocity.y < 0.5)) || right)
        {
            right = true;
            direction = new Vector3(0,0,-90f);
            down = false;
            up = false;
            left = false;
        }
        if ((rb.velocity.x < 0 && (rb.velocity.y > -0.5 && rb.velocity.y < 0.5)) || left)
        {
            left = true;
            direction =  new Vector3(0,0,-90);
            down = false;
            right = false;
            up = false;
        }


        //if (spriteR.sprite == up)
        //{
        //    direction = Vector2.up;
        //    Debug.Log("Up");
        //}
        //else if (spriteR.sprite == down)
        //{
        //    direction = new Vector2(0, -1);
        //    Debug.Log("Down");
        //}
        //else if (spriteR.sprite == left)
        //{
        //    direction = new Vector2(-1, 0);
        //    Debug.Log("Left");
        //}
        //else if (spriteR.sprite == right)
        //{
        //    direction = Vector2.right;
        //    Debug.Log("Right");
        //}



        return direction.normalized;
    }

    public Vector3 getPosition()
    {
        return playerPosition;
    }

    public void OnLaserHit()
    {
        RaycastHit2D laserHit = Physics2D.Raycast(transform.position, playerDirection(), 1000f, laserConnect);
        float spriteLength = laserHit.distance;
        Destroy(reflectedLaser);
        reflectedLaser = Instantiate(laserPrefab, transform.position, Quaternion.Euler(playerDirection()));
        reflectedLaser.GetComponent<SpriteRenderer>().size = new Vector2(1, spriteLength);
    }
}

