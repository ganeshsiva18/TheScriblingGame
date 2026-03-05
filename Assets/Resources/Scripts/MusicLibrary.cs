using UnityEngine;


[System.Serializable]
public struct Music
{
    public string trackName;
    public AudioClip clip;
}
public class MusicLibrary: MonoBehaviour
{
    public Music[] tracks;

    public AudioClip GetClipFromName(string trackName)
    {
        foreach (var track in tracks)
        {
            if (track.trackName == trackName)
            {
                return track.clip;
            }
        }

        return null;
    }

}
