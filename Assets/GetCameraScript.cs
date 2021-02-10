using UnityEngine;
using System.Collections;

public class GetCameraScript : MonoBehaviour
{
    public GameObject portalPrefab1;
    public GameObject portalPrefab2;
    private Camera camera;

    void Awake()
    {
        camera = GetComponent<Camera>();

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D collider = Physics2D.OverlapPoint(camera.ScreenToWorldPoint(Input.mousePosition));
            Debug.Log(collider);
            if (collider!= null)
            {
                if (collider.gameObject.tag == "PortalWall")
                {
                    Instantiate(portalPrefab1, collider.transform.position, Quaternion.identity);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Collider2D collider = Physics2D.OverlapPoint(camera.ScreenToWorldPoint(Input.mousePosition));
            if (collider!= null)
            {
                if (collider.gameObject.tag == "PortalWall")
                {
                    Instantiate(portalPrefab2,collider.transform.position, Quaternion.identity);
                }
            } 
        }
    }
}