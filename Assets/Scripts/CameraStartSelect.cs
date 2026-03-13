using UnityEngine;

public class CameraStartSelect : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
