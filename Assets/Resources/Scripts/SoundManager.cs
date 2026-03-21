using UnityEngine;
using UnityEngine.Audio;

public class SoundManager: MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private SoundLibrary sfxLibrary;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioMixerGroup sfxMixer;

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
    
    public void PlaySound2D(string soundName)
    {
        if (sfxLibrary.GetClipFromName(soundName) == null)
        {
            Debug.Log($"Clip '{soundName}' is null!");
        }
        sfxSource.PlayOneShot(sfxLibrary.GetClipFromName(soundName));
    }

    public void StopSound()
    {
        sfxSource.Stop();
    }

    public void PlaySoundPositional(string soundName, Vector2 position, float minDistance, float maxDistance)
    {
        GameObject tempAudioObj = new("tempAudioObj");
        tempAudioObj.transform.position = position;
        AudioSource tempAudioSource = tempAudioObj.AddComponent<AudioSource>();

        tempAudioSource.loop = false;
        tempAudioSource.clip = sfxLibrary.GetClipFromName(soundName);
        tempAudioSource.outputAudioMixerGroup = sfxMixer;
        tempAudioSource.spatialBlend = 1f;
        tempAudioSource.rolloffMode = AudioRolloffMode.Linear;
        tempAudioSource.minDistance = minDistance;
        tempAudioSource.maxDistance = maxDistance;

        if (tempAudioSource.clip == null)
        {
            Debug.Log($"Clip '{soundName}' is null!");
        }
        tempAudioSource.Play();
        Destroy(tempAudioObj, tempAudioSource.clip.length + 0.1f);
    }
}
