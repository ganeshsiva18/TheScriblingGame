using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance;

    [SerializeField] private List<int> dialogueTextRef;
    [SerializeField] private List<DialogueText> dialogueTextList;
    [SerializeField] private Animator animator;
    private bool hasBeenQuestioned = false;

    private void Awake()
    {
        Instance = this;
    }
    public void AskQuestion()
    {
        SoundManager.Instance.PlaySound2D("questionBell");
        animator.SetTrigger("questionUnreveal");
        if (!hasBeenQuestioned)
        {
            DialogueManager.Instance.DoDialogue(dialogueTextList[0]);
            PopQuestionFromList(0);
            hasBeenQuestioned = true;
            LetterManager.Instance.AddLetter('Q', transform.position);
        } else
        {
            DialogueManager.Instance.DoDialogue(dialogueTextList[Random.Range(0, dialogueTextList.Count)]);
        }
    }

    public void PopQuestionFromList(int keyToPop)
    {
        dialogueTextList.RemoveAt(dialogueTextRef.IndexOf(keyToPop));
        dialogueTextRef.Remove(keyToPop);
    }
}
