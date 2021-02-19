using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject door;
    private Animator doorAnimation;

    private void Awake()
    {
        doorAnimation = door.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Laser"))
        {
            doorAnimation.SetBool("SesamStulle", true);
        }
    }




}
