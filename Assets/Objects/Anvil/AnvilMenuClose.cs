using UnityEngine;

public class AnvilMenuClose : MonoBehaviour
{
    [SerializeField] InventoryItem sword;
    public void CloseAnvilMenu()
    {
        gameObject.SetActive(false);
        GameManager.Instance.canMove = true;

        char[] chars = { 'S', 'W', 'O', 'R', 'D' };
        LetterManager.Instance.AddLetters(chars, transform.position);
        InventoryManager.Instance.AddInventoryItem(sword);
    }
}
