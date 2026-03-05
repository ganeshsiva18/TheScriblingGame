using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager: MonoBehaviour
{
    private Animator settingsAnimator;
    private bool isOpen = false;

    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Button soundButton;
    [SerializeField] private Button musicButton;

    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider musicSlider;

    [SerializeField] private Canvas settingsUIRoll;
    [SerializeField] private TextMeshProUGUI settingsText;

    private Animator musicAnimator;
    private Animator soundAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingsAnimator = GetComponent<Animator>();
        musicAnimator = musicButton.GetComponent<Animator>();
        soundAnimator = soundButton.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OpenSettings()
    {
        if (settingsText.IsDestroyed() == false)
        {
            Destroy(settingsText.gameObject);
        }
        if (settingsAnimator != null && !isOpen)
        {
            isOpen = true;
            settingsAnimator.SetTrigger("trOpen");

            StartCoroutine(ButtonControl(0.75f, true));
            StartCoroutine(MusicAfterHalf(0, soundAnimator, "soundUnfurl"));
            StartCoroutine(MusicAfterHalf(0.75f / 2f, musicAnimator, "musicUnfurl"));
        }
        else if (settingsAnimator != null && isOpen)
        {
            isOpen = false;
            settingsAnimator.SetTrigger("trClosed");

            musicSlider.gameObject.SetActive(false);
            soundSlider.gameObject.SetActive(false);
            StartCoroutine(MusicAfterHalf(0, soundAnimator, "soundFurl"));
            StartCoroutine(MusicAfterHalf(0, musicAnimator, "musicFurl"));
            StartCoroutine(ButtonControl(0, false));
        }
    }

    private IEnumerator MusicAfterHalf(float time, Animator animator, string action)
    {
        yield return new WaitForSeconds(time);
        animator.SetTrigger(action);
    }

    private IEnumerator ButtonControl(float time, bool option)
    {
        yield return new WaitForSeconds(time);
        soundButton.interactable = option;
        musicButton.interactable = option;
    }

    public void MusicSliderVis(bool state)
    {
        if (musicButton.interactable == true)
        {
            musicSlider.gameObject.SetActive(state);
        }
    }

    public void SoundSliderVis(bool state)
    {
        if (soundButton.interactable == true)
        {
            soundSlider.gameObject.SetActive(state);
        }
    }

    public void closeSlider(Slider slider)
    {
        slider.gameObject.SetActive(false);
    }

    public void byeBye()
    {
        if (settingsAnimator != null)
        {
            if (settingsText.IsDestroyed() == false)
            {
                Destroy(settingsText.gameObject);
            }
            if (isOpen)
            {
                OpenSettings();
            }
            settingsAnimator.SetTrigger("trByeBye");
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

