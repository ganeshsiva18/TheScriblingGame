using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabiGameAI: MonoBehaviour
{
    [SerializeField] private InteractibleDefiner definer;
    [SerializeField] private SpriteRenderer tabiSprite;
    [SerializeField] private PauseManager pauseManager;
    [SerializeField] private GameObject gameScreenPrefab;
    [SerializeField] private DialogueText firstExclaimation;
    private GameObject gameScreenInstance;

    public int timesPlayed = 0;
    public bool isTabiGame = false;
    public bool instructionsClosed = false;
    public int health = 3;

    public bool interactible;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        interactible = definer.interactible;
    }

    private void LoadTabiGame()
    {
        gameScreenInstance = Instantiate(gameScreenPrefab, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
        gameScreenInstance.GetComponentInChildren<TabiGameController>().threatThreshold -= timesPlayed;
    }

    public IEnumerator TabiGuyCutscene(float gameStartTime)
    {
        if (timesPlayed == 0)
        {
            DialogueManager.Instance.DoDialogue(firstExclaimation);
        }
        GameManager.Instance.canSettings = false;
        isTabiGame = true;
        GameManager.Instance.canMove = false;
        tabiSprite.flipX = true;
        yield return new WaitForSeconds(gameStartTime);
        LoadTabiGame();
    }

    public void FlipSprite()
    {
        if (tabiSprite.flipX)
        {
            tabiSprite.flipX = false;
        } else
        {
            tabiSprite.flipX = true;
        }
    }

    public void WinTabiGame()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        foreach (var item in GetComponentsInChildren<BoxCollider2D>())
        {
            item.enabled = false;
        }

        health = 3;
        timesPlayed++;

        Destroy(gameScreenInstance);
        GetComponentInChildren<SpriteRenderer>().GetComponent<Animator>().SetTrigger("tabiDefeat");

        GameManager.Instance.tabiFinished = true;
        char[] charArray = { 'S', 'O', 'C', 'K', 'S' };
        LetterManager.Instance.AddLetters(charArray, GetComponentInChildren<SpriteRenderer>().transform.position);
        StartCoroutine(TabiDefeatCutscene());
    }

    public void ExitTabiGame()
    {
        GameManager.Instance.canMove = true;
        isTabiGame = false;
        health = 3;
        tabiSprite.flipX = false;
        timesPlayed++;
        GameManager.Instance.canSettings = true;
        Destroy(gameScreenInstance);
    }

    private IEnumerator TabiDefeatCutscene()
    {
        yield return new WaitForSeconds(2);
        GameManager.Instance.canMove = true;
        GameManager.Instance.canSettings = true;
    }
}
