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
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<CurrentItem>().currentItem == null)
        {
            if(item == ItemType.Mirror)
            {
                transform.position = new Vector3(6.92f, -2.56f, 0.0f);
                transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
                hasMirror = true;
            }
            else
            {
                transform.position = new Vector3(6.92f, -4.833f, 0.0f);
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
