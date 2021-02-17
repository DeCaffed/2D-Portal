using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalColor : MonoBehaviour

{
    [SerializeField] private Sprite redCrystal;
    [SerializeField] private Sprite purpleCrystal;
    private void FixedUpdate()
    {
        if (ChangeColor.isPurple)
        {
            GetComponent<SpriteRenderer>().sprite = purpleCrystal;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = redCrystal;
        }

    }
}
