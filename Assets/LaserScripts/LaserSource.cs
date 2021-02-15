using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSource : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1000f, (1 << LayerMask.NameToLayer("PrettyWall")) | ((1 << LayerMask.NameToLayer("Portal"))));
            if(hit.collider != null)
        {
            Debug.Log(hit.collider.tag);
        }
    }
}
