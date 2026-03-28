using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flairer: MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Flair());
    }

    private IEnumerator Flair()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
