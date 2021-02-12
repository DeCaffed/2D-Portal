using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingPortal : MonoBehaviour
{
    public GameObject greenPortal;
    bool greenPortalOnWall;
    public GameObject pinkPortal;
    bool pinkPortalOnWall;

    public GameObject portalWall;

    Vector3 portalTarget;

    // Start is called before the first frame update
    void Start()
    {
        greenPortalOnWall = false;
        pinkPortalOnWall = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position, 1000f, 1 << LayerMask.NameToLayer("PrettyWall"));
            if (hit.collider != null)
            {


                portalTarget = hit.transform.position - transform.position;
                Debug.DrawRay(transform.position, portalTarget, Color.green, 1f);
                Debug.Log(hit.collider.name);

                if (hit.transform.CompareTag("PortalWall"))
                {

                    // Grünes Portal
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (Vector2.Distance(hit.transform.position, pinkPortal.transform.position) <= 0.1f)
                        {
                            Debug.Log("Portale überlappen sich, grünes Portal nicht gesetzt");
                        }
                        else
                        {
                            if (!greenPortalOnWall)
                            {
                                greenPortalOnWall = true;
                                greenPortal = Instantiate(greenPortal, hit.collider.transform);
                                greenPortal.name = "GreenPortal";
                            }
                            greenPortal.transform.rotation = hit.transform.rotation;
                            greenPortal.transform.position = hit.collider.transform.position;
                        }
                    }


                    // Pinkes Portal
                    else if (Input.GetMouseButtonDown(1))
                    {
                        if (Vector2.Distance(hit.transform.position, greenPortal.transform.position) <= 0.1f)
                        {
                            Debug.Log("Portale überlappen sich, pinkes Portal nicht gesetzt");
                        }
                        else
                        {
                            if (!pinkPortalOnWall)
                            {
                                pinkPortalOnWall = true;
                                pinkPortal = Instantiate(pinkPortal, hit.collider.transform);
                                pinkPortal.name = "PinkPortal";
                            }
                            pinkPortal.transform.rotation = hit.transform.rotation;
                            pinkPortal.transform.position = hit.collider.transform.position;
                        }
                    }
                }
            }
        }
    }
}

