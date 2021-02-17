using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentItem : MonoBehaviour
{
    public Item currentItem;
    public Item mirrorPrefab;
    public Transform position;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Source") && currentItem != null)
        {
            //collision.gameObject.GetComponent    Kristallfarbe wird an die Source weiter gegeben.
            currentItem.UseItem();
            if (currentItem.item == Item.ItemType.BlueCrystal)
            {
                foreach(GameObject go in GameObject.FindGameObjectsWithTag("Laser")) {

                    go.GetComponent<ChangeColor>().setPurple();
                    Instantiate(mirrorPrefab, new Vector3(-1.4f, -3.8f, 0.0f), Quaternion.identity);
                }
                //gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0.6367924f, 0.6830202f);     //Lightly Red laser.
            }
        }
    }
}
