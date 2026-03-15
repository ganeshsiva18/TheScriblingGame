using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class OpenSceneScript: MonoBehaviour
{
    [SerializeField] private PlayableDirector startCutscene;
    [SerializeField] private TextMeshProUGUI skipText;
    [SerializeField] private DialogueText openingDialogue;
    [SerializeField] private GameObject player;
    private bool skippable = false;
    void Start()
    {
        GameManager.Instance.canMove = false;
        MusicManager.Instance.PlayMusic("MainMenu", 1);
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
        SceneManager.LoadScene(2);
    }

    public void SkipCutscene()
    {
        if (startCutscene.state == PlayState.Playing)
        {
            if (skippable)
            {
                StartCoroutine(DialogueManager.Instance.ClearDialogueTextAfterSeconds(0));
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

    public void PlayOpeningDialogue()
    {
        DialogueManager.Instance.DoDialogue(openingDialogue);
    }
}
