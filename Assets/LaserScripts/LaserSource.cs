using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSource : MonoBehaviour
{

    private bool isLaserShot;
    private bool ShootNextFrame;
    // Start is called before the first frame update
    void Start()
    {
        isLaserShot = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (ShootNextFrame)
        {
            ShootLaserAndGetTarget();
            ShootNextFrame = false;
        }
        if (isLaserShot)
        {
            isLaserShot = false;
            ShootNextFrame = true;
        }
    }

    public void AskToShootLaser()
    {
        isLaserShot = true;
    }

    private void ShootLaserAndGetTarget()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1000f, (1 << LayerMask.NameToLayer("PrettyWall")) | ((1 << LayerMask.NameToLayer("Portal"))));
        if (hit.collider != null && (hit.collider.CompareTag("PinkPortal") || hit.collider.CompareTag("GreenPortal")))
        {
            hit.collider.gameObject.GetComponent<PortalConnect>().LaserHit();
        }
        
    }
}