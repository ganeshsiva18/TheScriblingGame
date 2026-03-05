using UnityEngine;

public class LetterReferenceRoll: MonoBehaviour
{
    private Animator animator;
    private bool letterOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

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

