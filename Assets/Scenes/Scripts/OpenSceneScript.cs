using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class OpenSceneScript: MonoBehaviour
{
    [SerializeField] private PlayableDirector startCutscene;
    [SerializeField] private TextMeshProUGUI skipText;
    [SerializeField] private GameObject player;
    private bool skippable = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.canMove = false;
        MusicManager.Instance.PlayMusic("MainMenu", 1);
    }

    // Update is called once per frame
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

    public void playerSceneStart()
    {
        SceneManager.LoadScene(2);
    }

    public void skipCutscene()
    {
        if (startCutscene.state == PlayState.Playing)
        {
            if (skippable)
            {
                playerSceneStart();
            }
            StartCoroutine(startCutsceneSkip());
        }
    }
        
    private IEnumerator startCutsceneSkip()
    {
        skippable = true;
        yield return new WaitForSeconds(3);
        skippable = false;
    }
}
