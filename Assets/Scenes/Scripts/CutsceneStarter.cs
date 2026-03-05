using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class CutsceneStarter: MonoBehaviour
{
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button skipButton;
    [SerializeField] private PlayableDirector cutscene;
    [SerializeField] private TextMeshProUGUI scrollText;

    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cutsceneStart()
    {
        GameManager.Instance.sfxAudio = sfxSlider.value;
        GameManager.Instance.musicAudio = musicSlider.value;
        settingsButton.GetComponent<SettingsManager>().byeBye();
        Destroy(scrollText);
        skipButton.gameObject.SetActive(true);

        cutscene.Play();
        Destroy(gameObject);
    }
}
