using Unity.Cinemachine;
using UnityEngine;

public class CameraScript: MonoBehaviour
{
    private GameObject player;
    private CinemachineCamera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        cam = GetComponent<CinemachineCamera>();

        cam.Follow = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
