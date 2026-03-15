using UnityEngine;

public class CameraStartSelect : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    void Awake()
    {
        canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
}
