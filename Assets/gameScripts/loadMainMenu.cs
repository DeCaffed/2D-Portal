using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadMainMenu : MonoBehaviour
{

    public void LoadMenu(string menu)
    {
        SceneManager.LoadScene("menu");
    }

}
