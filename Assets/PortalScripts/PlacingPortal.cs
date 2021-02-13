using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingPortal : MonoBehaviour
{
    public GameObject greenPortal;
    public Sprite greenPortalTopSprite;
    public Sprite greenPotalRightSprite;
    public Sprite greenPortalLeftSprite;
    bool greenPortalOnWall;

    public GameObject pinkPortal;
    public Sprite pinkPortalTopSprite;
    public Sprite pinkPotalRightSprite;
    public Sprite pinkPortalLeftSprite;
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
                //Debug.Log(hit.collider.name);

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
                            // Portal wird gedreht, je nach Wand
                            greenPortal.transform.rotation = hit.transform.rotation;
                            float angleOfPortal = hit.transform.rotation.eulerAngles.z;

                            if (angleOfPortal == 0)
                            {
                                greenPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = greenPortalTopSprite;
                                greenPortal.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                                greenPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
                                greenPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = false;
                            }
                            else if (angleOfPortal == 90)
                            {
                                greenPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = greenPortalLeftSprite;
                                greenPortal.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                                greenPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
                                greenPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
                            }
                            else if (angleOfPortal == 270)
                            {
                                greenPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = greenPotalRightSprite;
                                greenPortal.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                                greenPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
                                greenPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
                            }

                            greenPortal.transform.position = hit.collider.transform.position;
                        }
                    }


                    // Pinkes Portal
                    if (Input.GetMouseButtonDown(1))
                    {
                        if (Vector2.Distance(hit.transform.position, greenPortal.transform.position) <= 0.1f)
                        {
                            Debug.Log("Portale überlappen sich, grünes Portal nicht gesetzt");
                        }
                        else
                        {
                            if (!pinkPortalOnWall)
                            {
                                pinkPortalOnWall = true;
                                pinkPortal = Instantiate(pinkPortal, hit.collider.transform);
                                pinkPortal.name = "GreenPortal";
                            }
                            // Portal wird gedreht, je nach Wand
                            pinkPortal.transform.rotation = hit.transform.rotation;
                            float angleOfPortal = hit.transform.rotation.eulerAngles.z;

                            if (angleOfPortal == 0)
                            {
                                pinkPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = pinkPortalTopSprite;
                                pinkPortal.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                                pinkPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
                                pinkPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = false;
                            }
                            else if (angleOfPortal == 90)
                            {
                                pinkPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = pinkPortalLeftSprite;
                                pinkPortal.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                                pinkPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
                                pinkPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
                            }
                            else if (angleOfPortal == 270)
                            {
                                pinkPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = pinkPotalRightSprite;
                                pinkPortal.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                                pinkPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
                                pinkPortal.transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
                            }

                            pinkPortal.transform.position = hit.collider.transform.position;
                        }
                    }
                }
            }
        }
    }
}

