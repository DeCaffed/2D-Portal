using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
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
                transform.position = new Vector3(7.02f, -2.56f, 0.0f);
                transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            }
            else
            {
                transform.position = new Vector3(7, -4.85f, 0);
                transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
                collision.gameObject.GetComponent<CurrentItem>().currentItem = this;
            }
        }
    }
}
