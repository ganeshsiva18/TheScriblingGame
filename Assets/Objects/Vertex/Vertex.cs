using System;
using UnityEngine;

public class Vertex : MonoBehaviour
{
    [SerializeField] private InventoryItem obolPiece2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            char[] c = { 'V', 'E', 'R', 'T', 'E', 'X' };
            LetterManager.Instance.AddLetters(c, gameObject.transform.position);
            InventoryManager.Instance.AddInventoryItem(obolPiece2);
            GameManager.Instance.vertexCrushed = true;
            Destroy(gameObject);
        }
    }
}
