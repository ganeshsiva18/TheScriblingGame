using UnityEngine;

public class FireWhoosh: MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundManager.Instance.PlaySound2D("fireWhoosh");
    }
}
