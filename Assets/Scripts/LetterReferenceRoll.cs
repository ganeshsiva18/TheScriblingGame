using UnityEngine;

public class LetterReferenceRoll: MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool letterOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {

    }

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

