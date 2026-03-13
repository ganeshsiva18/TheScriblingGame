using UnityEngine;

public class FinalSceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
