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

    // If the dummy was hit
    public bool dummyHit = false;

    // If the tabi game has been finished
    public bool tabiFinished = false;

    // If the fish has been collected
    public bool fishCollected = false;

    // Audio and Music levels
    public float sfxAudio;
    public float musicAudio;

    private bool playerScene = false;
    private GameObject playerHUD;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScene) 
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
    public void PlayerSceneCheck()
    {
        playerScene = true;
        playerHUD = GameObject.FindGameObjectWithTag("Player HUD");
        DialogueManager.Instance.GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

}
