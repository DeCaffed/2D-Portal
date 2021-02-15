using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSource : MonoBehaviour
{

    private bool isLaserShot;
    // Start is called before the first frame update
    void Start()
    {
        isLaserShot = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isLaserShot)
        {
            ShootLaserAndGetTarget();
            isLaserShot = false;
        }
    }

    public void AskToShootLaser()
    {
        isLaserShot = true;
    }

    private Collider2D ShootLaserAndGetTarget()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1000f, (1 << LayerMask.NameToLayer("PrettyWall")) | ((1 << LayerMask.NameToLayer("Portal"))));
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.tag);
        }
        return hit.collider;
    }
}