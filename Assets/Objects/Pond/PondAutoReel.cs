using UnityEngine;

public class PondAutoReel : MonoBehaviour
{
    [SerializeField] private PondManager pondManager;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && pondManager.getFishingState())
        {
            pondManager.ReelLine();
        }
    }
}
