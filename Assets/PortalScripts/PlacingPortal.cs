using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingPortal : MonoBehaviour
{
    public GameObject GreenPortal;
    public GameObject PinkPortal;
    public GameObject PortalWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.green, 1f);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 1000f, 1 << LayerMask.NameToLayer("PrettyWall"));
            Debug.Log(hit.collider.name);
            if (hit.collider.tag == "PortalWall")
            {
                GameObject tmpPortal = Instantiate(GreenPortal, hit.collider.transform );
            }
        }
    }
    //Detect if the right mouse button is pressed
 
   

}

