using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalCollide : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Source")
        {
            collision.gameObject.GetComponent<ChangeColor>().setPurple();
        }

    }
}
