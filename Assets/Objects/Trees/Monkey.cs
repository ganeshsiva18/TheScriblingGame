using UnityEngine;
using UnityEngine.SceneManagement;

public class Monkey : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.canSettings = false;
        GameManager.Instance.canMove = false;
        GameManager.Instance.playerScene = false;
        SceneManager.LoadSceneAsync(3);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
