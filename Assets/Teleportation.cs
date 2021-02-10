using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public float Offset = 0.5f;
    public bool isactived = true;
    public Teleportation Portal;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && isactived)
        {
            Portal.PortalOff();
            StartCoroutine(Teleport());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isactived = true;
    }
    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = Portal.transform.position+Portal.transform.up*Offset;
    }
    public void PortalOff()
    {
        isactived = false;
    }
}
