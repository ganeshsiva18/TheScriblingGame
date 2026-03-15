using UnityEngine;

public class MonkeyDestroy : MonoBehaviour
{
    // Destroys the monkey object after 5 seconds
    void Start()
    {
        Destroy(gameObject, 5f);
    }
}
