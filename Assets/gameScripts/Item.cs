using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private static bool hasMirror;
    public enum ItemType
    {
        BlueCrystal,
        Mirror,
    }
    public ItemType item;

    public void UseItem()
    {
        Destroy(gameObject);
    }

    public GameObject itemInventar;
    public GameObject mirrorInventar;

    void Start()
    {
        itemInventar = GameObject.FindGameObjectWithTag("ItemBoxInventarSlot");
        mirrorInventar = GameObject.FindGameObjectWithTag("MirrorBoxInventarSlot");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<CurrentItem>().currentItem == null)
        {
            // Spiegelei
            if (item == ItemType.Mirror)
            {
                transform.position = mirrorInventar.transform.position;
                transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
                hasMirror = true;
            }

            // Item
            else
            {
                transform.position = itemInventar.transform.position - new Vector3(0f, 0.2f, 0f);
                transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
                collision.gameObject.GetComponent<CurrentItem>().currentItem = this;
            }
        }
    }
    public static bool GetMirror()
    {
        return hasMirror;
    }
}
