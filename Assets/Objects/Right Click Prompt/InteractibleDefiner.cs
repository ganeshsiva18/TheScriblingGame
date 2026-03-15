using UnityEngine;

public class InteractibleDefiner: MonoBehaviour
{
    [SerializeField] private GameObject rightClickPrompt;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    public bool interactible;
    private GameObject rightClickPromptObject;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.canMove)
        {
            Destroy(rightClickPromptObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactible = true;
            if (GameManager.Instance.canMove)
            {
                rightClickPromptObject = Instantiate(rightClickPrompt, new Vector2(transform.position.x + xOffset, transform.position.y + yOffset), Quaternion.identity);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactible = false;
            Destroy(rightClickPromptObject);
        }
    }
}
