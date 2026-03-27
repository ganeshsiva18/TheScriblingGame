using System.Collections;
using UnityEngine;

public class MusicManager: MonoBehaviour
{
    public static MusicManager Instance;
    [SerializeField] private MusicLibrary musicLibrary;
    [SerializeField] private AudioSource musicSource;
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

    public void PlayMusic(string trackName, float fadeDuration)
    {
        StartCoroutine(AnimatePlayMusic(musicLibrary.GetClipFromName(trackName), fadeDuration));
    }

    public void StopMusic(float fadeDuration)
    {
        StartCoroutine(AnimateStopMusic(fadeDuration));
    }

    IEnumerator AnimateStopMusic(float fadeDuration) 
    {
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / fadeDuration;
            musicSource.volume = Mathf.Lerp(1f, 0, percent);
            yield return null;
        }
    }

    IEnumerator AnimatePlayMusic(AudioClip nextTrack, float fadeDuration)
    {
        musicSource.clip = nextTrack;
        musicSource.volume = 0;
        musicSource.Play();

        float percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime / fadeDuration;
            musicSource.volume = Mathf.Lerp(0, 1f, percent);
            yield return null;
        }

        musicSource.volume = 1f;
    }

    IEnumerator AnimateMusicCrossfade(AudioClip nextTrack, float fadeDuration)
    {
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / fadeDuration;
            musicSource.volume = Mathf.Lerp(1f, 0, percent);
            yield return null;
        }

        musicSource.clip = nextTrack;
        musicSource.volume = 0;
        musicSource.Play();

        percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime / fadeDuration;
            musicSource.volume = Mathf.Lerp(0, 1f, percent);
            yield return null;
        }

        musicSource.volume = 1f;
    }
}