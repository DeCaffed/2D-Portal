using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public float offset;
    public bool isActive;
    private Teleportation portal;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        offset = 0.5f;
        isActive = true;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isActive)
        {
            // Bin ich das pinke Portal?
            if (this.CompareTag("PinkPortal"))
            {
                // Gibt es schon das grüne Portal?
                if (GameObject.FindGameObjectWithTag("GreenPortal"))
                {
                    portal = GameObject.FindGameObjectWithTag("GreenPortal").GetComponent<Teleportation>();
                }
                else
                {
                    return;
                }
            }

            // ... oder bin ich das grüne Portal?
            else
            {
                // Gibt es schon das pink Portal?
                if (GameObject.FindGameObjectWithTag("PinkPortal"))
                {
                    portal = GameObject.FindGameObjectWithTag("PinkPortal").GetComponent<Teleportation>();
                }
                else
                {
                    return;
                }
            }

            portal.PortalOff();
            StartCoroutine(Teleport());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isActive = true;
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.1f);
        player.transform.position = portal.transform.position + portal.transform.up * -offset;
    }

    public void PortalOff()
    {
        isActive = false;
    }
}
