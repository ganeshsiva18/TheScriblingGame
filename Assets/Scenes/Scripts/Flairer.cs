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

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Flair()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
