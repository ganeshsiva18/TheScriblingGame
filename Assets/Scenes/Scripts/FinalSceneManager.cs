using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class FinalSceneManager : MonoBehaviour
{
    [SerializeField] PlayableDirector finaleTimeline;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        MusicManager.Instance.StopMusic(0);
        StartCoroutine(FinaleStart());
    }

    IEnumerator FinaleStart()
    {
        yield return new WaitForSeconds(5);
        finaleTimeline.Play();
    }
}
