using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class FinalSceneManager : MonoBehaviour
{
    [SerializeField] PlayableDirector finaleTimeline;
    [SerializeField] DialogueText[] texts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(0, 0);
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        MusicManager.Instance.StopMusic(0.01f);
        SoundManager.Instance.PlaySound2D("finalSceneEnter");
        StartCoroutine(FinaleStart());
    }

    IEnumerator FinaleStart()
    {
        yield return new WaitForSeconds(5);
        finaleTimeline.Play();
        MusicManager.Instance.PlayMusic("Ending", 5);
    }

    public void FinalDialogueBegin(int dialogueNum)
    {
        DialogueManager.Instance.DoDialogue(texts[dialogueNum]);
    }
}
