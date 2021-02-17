using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChangeColor : MonoBehaviour
{
    public Sprite redLaser;
    public Sprite purpleLaser;
    public static bool isPurple;

    private void Start()
    {
        isPurple = false;
    }


    public void setPurple()
    {
        GetComponent<SpriteRenderer>().sprite = purpleLaser;
        isPurple = true;
    }

}
    
    
