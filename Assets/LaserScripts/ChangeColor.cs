using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChangeColor : MonoBehaviour
{
    public Sprite redLaser;
    public Sprite purpleLaser;
    
    public void setPurple()
    {
        GetComponent<SpriteRenderer>().sprite = purpleLaser;
    }

}
    
    
