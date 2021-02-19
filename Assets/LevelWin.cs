using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWin : MonoBehaviour
{
    public int daSollEsWeiterGehen;

    IEnumerator LoadEndscreen()
    {
        yield return new WaitForSeconds(0.5f);


        if (daSollEsWeiterGehen != 0)
        {
            SceneManager.LoadScene(daSollEsWeiterGehen);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadEndscreen());
        }

    }
}
