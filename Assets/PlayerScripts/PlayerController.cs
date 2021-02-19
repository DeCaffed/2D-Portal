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
    [SerializeField] GameObject laserPrefab;
    [SerializeField] private LayerMask laserConnect;

    private CurrentItem inventar;
    public bool binVollImLazerDrin;
    public Transform positionOriginalLaser;

    bool up;
    bool down;
    bool right;
    bool left;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inventar = GetComponent<CurrentItem>();
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        animator.SetFloat("left - right", horizontalInput); animator.SetFloat("up - down", verticalInput);

        if (binVollImLazerDrin)
        {
            OnLaserHit();
        }
        else
        {
            Destroy(reflectedLaser);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            if (inventar.hasMirror)
            {
                binVollImLazerDrin = true;
                positionOriginalLaser = collision.gameObject.transform;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            if (inventar.hasMirror)
            {
                binVollImLazerDrin = true;
                positionOriginalLaser = collision.gameObject.transform;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            if (inventar.hasMirror)
            {
                Debug.Log("Bobbele ist rausgefallen");
                binVollImLazerDrin = false;
            }
        }
    }


    private void FixedUpdate()
    {
        playerPosition = transform.position;
        rb.velocity = (Vector2.up * verticalInput + Vector2.right * horizontalInput).normalized * movementSpeed;
    }


    public Vector2 PlayerDirection()
    {
        float banana = 1f;
        Vector2 direction = Vector2.zero;
        //float help = Input.GetAxisRaw("Vertical") + Input.GetAxisRaw("Horizontal");
        if ((rb.velocity.y > 0 && (rb.velocity.x > -0.5 && rb.velocity.x < 0.5)) || up)
        {
            up = true;
            direction = new Vector2(0f, banana);
            down = false;
            right = false;
            left = false;
        }
        if ((rb.velocity.y < 0 && (rb.velocity.x > -0.5 && rb.velocity.x < 0.5)) || down)
        {
            down = true;
            direction = new Vector2(0f, -banana);
            up = false;
            right = false;
            left = false;
        }
        if ((rb.velocity.x > 0 && (rb.velocity.y > -0.5 && rb.velocity.y < 0.5)) || right)
        {
            right = true;
            direction = new Vector2(banana, 0);
            down = false;
            up = false;
            left = false;
        }
        if ((rb.velocity.x < 0 && (rb.velocity.y > -0.5 && rb.velocity.y < 0.5)) || left)
        {
            left = true;
            direction = new Vector2(-banana, 0);
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


        // WHY IS THIS CODE HERE?!
        return direction.normalized;
        // IT DOES NOTHING!!!
        // re: Too bad!
    }


    public Vector3 GetPosition()
    {
        return playerPosition;
    }

    public void OnLaserHit()
    {
        RaycastHit2D laserHit = Physics2D.Raycast(positionOriginalLaser.transform.position, Vector2.up, 1000f, laserConnect | (1 << LayerMask.NameToLayer("PrettyWall")));
        float spriteLength = laserHit.distance;
        if (laserHit.collider != null)
        {
            if (reflectedLaser == null)
            {
                reflectedLaser = Instantiate(laserPrefab, positionOriginalLaser);
                reflectedLaser.GetComponent<BoxCollider2D>().size = new Vector2(0.1f, spriteLength);
            }

            Vector3 newLaserAngle;
            /*
            // Richtung oben oder unten
            if (PlayerDirection().y != 0f && PlayerDirection().x == 0)
            { */
                newLaserAngle = new Vector3(0f, 0f, 0f);
                reflectedLaser.transform.position = new Vector3(transform.position.x, (Vector2.Distance(laserHit.transform.position, positionOriginalLaser.transform.position) / 2) + 1f, 0f);
            /* }

            // Richtung links oder rechts
            else
            {
                newLaserAngle = new Vector3(0f, 0f, 90f);
                reflectedLaser.transform.position = new Vector3((Vector2.Distance(laserHit.transform.position, transform.position) / 2) * PlayerDirection().x, transform.position.y, 0f);
            }
            */
            reflectedLaser.transform.eulerAngles = newLaserAngle;
            



            reflectedLaser.GetComponent<SpriteRenderer>().size = new Vector2(1f, spriteLength);
        }
    }
}

