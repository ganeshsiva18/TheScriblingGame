using System.Linq.Expressions;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    public static GameManager Instance;

    // If the settings is open
    public bool isSettings = false;

    // If the settings can be opened
    public bool canSettings = true;

    // If player can move
    public bool canMove = true;

    // Audio and Music levels
    public float sfxAudio;
    public float musicAudio;

    public bool playerScene = false;
    private GameObject playerHUD;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Update()
    {
        if (playerScene && playerHUD != null) 
        {
            if (!canMove)
            {
                playerHUD.SetActive(false);
            }
            else
            {
                playerHUD.SetActive(true);
            }
        }
    }

    // Reload references on scene change
    public void PlayerSceneCheck()
    {
        playerScene = true;
        playerHUD = GameObject.FindGameObjectWithTag("Player HUD");
        DialogueManager.Instance.GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

}
