using UnityEngine;

public class PlayerSceneManager: MonoBehaviour
{
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MusicManager.Instance.StopMusic(0);
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        GameManager.Instance.canMove = true;
        GameManager.Instance.PlayerSceneCheck();
    }
}
