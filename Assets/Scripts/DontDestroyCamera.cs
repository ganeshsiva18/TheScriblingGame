using UnityEngine;

public class DontDestroyCamera : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
