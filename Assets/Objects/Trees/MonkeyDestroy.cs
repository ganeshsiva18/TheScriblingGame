using UnityEngine;

public class MonkeyDestroy : MonoBehaviour
{
    // Destroys the monkey object after 5 seconds
    void Start()
    {
        SoundManager.Instance.PlaySound2D("monkey");
        Destroy(gameObject, 5f);
    }
}
