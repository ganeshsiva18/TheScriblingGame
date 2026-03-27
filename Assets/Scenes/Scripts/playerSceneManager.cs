using UnityEngine;

public class PlayerSceneManager: MonoBehaviour
{
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MusicManager.Instance.PlayMusic("Player", 3);
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        GameManager.Instance.canMove = true;
        GameManager.Instance.PlayerSceneCheck();

        char[] chars = { 'C', 'O', 'N', 'J', 'U', 'R', 'E' };
        LetterManager.Instance.AddLetters(chars, new Vector2(0,0));
    }
}
