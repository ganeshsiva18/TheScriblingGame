using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private DialogueText[] dialogueText;
    [SerializeField] private Dictionary<int, DialogueText> dialogueTextPair = new();
    private bool hasBeenQuestioned = false;
    public static QuestionManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void AskQuestion()
    {
        if (!hasBeenQuestioned)
        {
            DialogueManager.Instance.DoDialogue(dialogueText[0]);
            hasBeenQuestioned = true;
            LetterManager.Instance.AddLetter('Q', transform.position);
        } else
        {
            if (!GameManager.Instance.tabiFinished)
            {
                DialogueManager.Instance.DoDialogue(dialogueText[1]);
            }
            else if (!GameManager.Instance.dummyHit)
            {
                DialogueManager.Instance.DoDialogue(dialogueText[2]);
            }
            else if (!GameManager.Instance.pondEmpty)
            {
                DialogueManager.Instance.DoDialogue(dialogueText[3]);
            }
            else if (!GameManager.Instance.ifEyesNotTalked)
            {
                DialogueManager.Instance.DoDialogue(dialogueText[4]);
            }
            else if (!GameManager.Instance.monkeyTreeShook)
            {
                DialogueManager.Instance.DoDialogue(dialogueText[5]);
            }
            else if (!GameManager.Instance.goldenTreeShook)
            {
                DialogueManager.Instance.DoDialogue(dialogueText[6]);
            }
            else if (!GameManager.Instance.anvilUsed)
            {
                DialogueManager.Instance.DoDialogue(dialogueText[7]);
            }
            else if (!GameManager.Instance.ringBroken)
            {
                DialogueManager.Instance.DoDialogue(dialogueText[8]);
            }
            else if (!GameManager.Instance.vertexCrushed)
            {
                DialogueManager.Instance.DoDialogue(dialogueText[9]);
            }
            else
            {
                DialogueManager.Instance.DoDialogue(dialogueText[10]);
            }
        }
    }

    public void PopQuestionFromList(int keyToPop)
    {
        dialogueTextPair.Remove(keyToPop);
    }
}
