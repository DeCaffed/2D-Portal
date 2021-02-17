using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentItem : MonoBehaviour
{
    public Item currentItem;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Source") && currentItem != null)
        {
            //collision.gameObject.GetComponent    Kristallfarbe wird an die Source weiter gegeben.
            currentItem.UseItem();
            //gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0.6367924f, 0.6830202f);     //Lightly Red laser.
        }
    }
}
