using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalConnect : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject redPrefab;
    [SerializeField] private GameObject purplePrefab;
    [SerializeField] private LayerMask laserConnect;
    private PlayerController player;
    private PortalConnect otherPortal;

    private bool touchLaser = false;
    public bool playerHit;
    public enum Direction
    {
        left,
        right,
        up,
    }

    private Direction direction;

    public GameObject laser;
    BoxCollider2D laserCollider;

    public void SetDirection(PortalConnect.Direction newDirection)
    {
        direction = newDirection;
    }

    public void SetPartner(PortalConnect partner)
    {
        touchLaser = false;
        otherPortal = partner;
        if (otherPortal.laser != null)
        {
            otherPortal.DestroyLaser();
        }
        if (laser != null)
        {
            DestroyLaser();
        }
        if (partner.TouchLaser())
        {
            ShootNewLaser();
        }
    }

    public void LaserHit()
    {
        if (otherPortal != null && !touchLaser)
        {
            touchLaser = true;
            otherPortal.ShootNewLaser();
        }
    }

    public void ShootNewLaser()
    {
        float spriteLength = CheckRayCastDistance();
        Vector3 spriteDirection = Vector3.zero;
        Vector3 spriteSpawnDirection = Vector3.zero;

        switch (direction)
        {
            case Direction.left:
                spriteDirection = Vector3.forward * 270;
                spriteSpawnDirection = transform.position + Vector3.right * (spriteLength / 2);
                break;
            case Direction.right:
                spriteDirection = Vector3.forward * 90;
                spriteSpawnDirection = transform.position + Vector3.left * (spriteLength / 2);
                break;
            case Direction.up:
                spriteDirection = Vector3.forward * 180;
                spriteSpawnDirection = transform.position + Vector3.down * (spriteLength / 2);
                break;
        }

        laser = Instantiate(laserPrefab, spriteSpawnDirection, Quaternion.Euler(spriteDirection), transform);
        laser.GetComponent<SpriteRenderer>().size = new Vector2(1f, spriteLength);
        
        laserCollider = laser.GetComponent<BoxCollider2D>();
        laserCollider.size = new Vector2(0.1f, laser.GetComponent<SpriteRenderer>().size.y);


    }

    public float CheckRayCastDistance()
    {
        Vector3 vectorDirection = Vector3.zero;
        switch (direction)
        {
            case Direction.left:
                vectorDirection = Vector3.right;
                break;
            case Direction.right:
                vectorDirection = Vector3.left;
                break;
            case Direction.up:
                vectorDirection = Vector3.down;
                break;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, vectorDirection, 1000f, laserConnect);
        if (hit.collider.gameObject.CompareTag("Player") && Item.GetMirror())
        {
            player.OnLaserHit();
        }
        else
        {
            playerHit = false;
        }
        return hit.distance;
    }

    public void DestroyLaser()
    {
        Destroy(laser);
    }
    public bool TouchLaser()
    {
        return touchLaser;
    }


    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (ChangeColor.isPurple)
        {
            laserPrefab = purplePrefab;
        }
        else
        {
            laserPrefab = redPrefab;
        }

        if (!Item.GetMirror())
        {
            laserConnect = LayerMask.GetMask("LaserCollide");
        }
        else
        {
            laserConnect += LayerMask.GetMask("Player");
        }

    }
}