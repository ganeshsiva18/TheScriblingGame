using System.Collections;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

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
            dialogueTimer += Time.deltaTime;
        } 
    }
    public void DoDialogue(DialogueText text)
    {
        dialogueText = text;
        dialogueTextBubble.alpha = 1;
        titleTextBubble.alpha = 1;

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

    private IEnumerator ClearDialogueTextAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        titleAnimator.SetTrigger("textFadeOut");
        dialogueAnimator.SetTrigger("textFadeOut");
    }
}
