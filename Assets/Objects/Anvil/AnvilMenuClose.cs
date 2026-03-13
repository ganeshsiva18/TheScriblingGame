using UnityEngine;

public class AnvilMenuClose : MonoBehaviour
{
    [SerializeField] InventoryItem sword;
    public void CloseAnvilMenu()
    {
        gameObject.SetActive(false);
        GameManager.Instance.canMove = true;
        GameManager.Instance.anvilUsed = true;
        char[] chars = { 'B', 'L', 'A', 'D', 'E' };
        LetterManager.Instance.AddLetters(chars, transform.position);
        InventoryManager.Instance.AddInventoryItem(sword);
    }
}
