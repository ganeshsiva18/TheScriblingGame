using UnityEngine;

public class LetterReferenceRoll: MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool letterOpen = false;

    public void LetterReferenceOpen()
    {
        if (!letterOpen)
        {
            animator.SetTrigger("lettersOpen");
            letterOpen = true;
        }
    }

    public void LetterReferenceClose()
    {
        if (letterOpen)
        {
        animator.SetTrigger("lettersClose");
        letterOpen = false;
        }
    }

    public void LetterReferenceSwap()
    {
        if (!letterOpen)
        {
            LetterReferenceOpen();
        } else
        {
            LetterReferenceClose();
        }
    }
}

