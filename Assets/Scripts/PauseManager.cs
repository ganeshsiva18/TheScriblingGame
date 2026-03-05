using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseManager: MonoBehaviour
{
    private GameActions gameActions;

    [SerializeField] private GameObject letterRef;
    [SerializeField] private GameObject settings;
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        gameActions.Enable();
    }

    void OnDisable()
    {
        gameActions.Disable();
    }
    private void Start()
    {
        musicSlider.value = GameManager.Instance.musicAudio;
        sfxSlider.value = GameManager.Instance.sfxAudio;
    }
    void Awake()
    {
        gameActions = new GameActions();
        gameActions.Character.Pause.canceled += OnKeyReleased;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OpenSettings()
    {
        GameManager.Instance.isSettings = true;
        GameManager.Instance.canMove = false;
        Time.timeScale = 0f;

        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        GameManager.Instance.isSettings = false;
        GameManager.Instance.canMove = true;
        Time.timeScale = 1f;

        settings.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }


    private void OnKeyReleased(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.isSettings == false && GameManager.Instance.canSettings)
        {
            OpenSettings();
        }
        else if (GameManager.Instance.isSettings == true)
        {
            CloseSettings();
        }
    }

    public void sfxChange(float volume)
    {
        audioMixer.SetFloat("sfxVol", volume);
    }
    public void musicChange(float volume)
    {
        audioMixer.SetFloat("musicVol", volume);
    }
}
