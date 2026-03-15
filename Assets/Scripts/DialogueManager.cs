using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    readonly private char ENDOFTEXT = '~';
    readonly private char ENDOFSTANCE = '|';
    readonly private char PAUSECHAR = '*';
    readonly private float NORMALTEXT = 0.075f;

    // Text to print and where to print
    [SerializeField] private TextMeshProUGUI titleTextBubble;
    [SerializeField] private TextMeshProUGUI dialogueTextBubble;
    [SerializeField] private Animator titleAnimator;
    [SerializeField] private Animator dialogueAnimator;
    private DialogueText dialogueText;

    // Condition for printing
    private bool printDialogue = false;

    // Current delay and char to print
    private float currentDelay = 0.075f;
    private char targetToPrint;

    // Current delay and timer to do dialogue
    private float dialogueVoiceTimer = 0;

    // Timers for printing
    private float dialogueTimer = 0;

    // Index for printing
    private int textNum = 0;
    private int pauseNum = 0;
    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        } else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }
    void Update()
    {
        if (printDialogue)
        {
            PrintChar();
            DoDialogueVoice();
            dialogueTimer += Time.unscaledDeltaTime;
            dialogueVoiceTimer += Time.unscaledDeltaTime;
        } 
    }
    public void DoDialogue(DialogueText text)
    {
        dialogueText = text;
        StopAllCoroutines();
        titleAnimator.SetTrigger("textFadeIn");
        dialogueAnimator.SetTrigger("textFadeIn");

        titleTextBubble.text = text.title;
        dialogueTextBubble.text = "";

        printDialogue = true;
        dialogueTimer = 0;
        textNum = 0;
        pauseNum = 0;
        currentDelay = NORMALTEXT;
    }

    private void PrintChar()
    {
        if (dialogueTimer >= currentDelay)
        {
            RaiseSetCharSelected();
            if (targetToPrint == ENDOFTEXT)
            {
                printDialogue = false;
                StartCoroutine(ClearDialogueTextAfterSeconds(dialogueText.waitTimeToExitDialogue));
            }
            else if (targetToPrint == ENDOFSTANCE)
            {
                dialogueTextBubble.text = "";
                dialogueTimer = currentDelay;
            } else if (targetToPrint == PAUSECHAR)
            {
                currentDelay = dialogueText.pauses[pauseNum];
                pauseNum++;
            } else
            {
                dialogueTextBubble.text += targetToPrint;
                dialogueTimer = 0;
            }
        }
    }

    private void RaiseSetCharSelected()
    {
        targetToPrint = dialogueText.dialogue[textNum];
        textNum++;
    }

    private void DoDialogueVoice()
    {
        if (dialogueVoiceTimer >= currentDelay * 4)
        {
            SoundManager.Instance.PlaySound2D("deepvoice");
            dialogueVoiceTimer = 0;
        }
    }

    public IEnumerator ClearDialogueTextAfterSeconds(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        titleAnimator.SetTrigger("textFadeOut");
        dialogueAnimator.SetTrigger("textFadeOut");
    }
}
