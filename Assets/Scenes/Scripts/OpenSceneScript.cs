using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class OpenSceneScript: MonoBehaviour
{
    [SerializeField] private PlayableDirector startCutscene;
    [SerializeField] private TextMeshProUGUI skipText;
    [SerializeField] private DialogueText[] openingDialogues;
    [SerializeField] private GameObject player;
    private bool skippable = false;
    void Start()
    {
        GameManager.Instance.canMove = false;
        MusicManager.Instance.PlayMusic("MainMenu", 0);
    }
    void Update()
    {
        if (skippable)
        {
            skipText.alpha = 1;
        }
        else
        {
            skipText.alpha = 0;
        }
    }

    public void PlayerSceneStart()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void SkipCutscene()
    {
        if (startCutscene.state == PlayState.Playing)
        {
            if (skippable)
            {
                DialogueManager.Instance.ClearDialogue();
                PlayerSceneStart();
            }
            StartCoroutine(StartCutsceneSkip());
        }
    }
        
    private IEnumerator StartCutsceneSkip()
    {
        skippable = true;
        yield return new WaitForSeconds(3);
        skippable = false;
    }

    public void PlayOpeningDialogue(int index)
    {
        DialogueManager.Instance.DoDialogue(openingDialogues[index]);
    }
}
