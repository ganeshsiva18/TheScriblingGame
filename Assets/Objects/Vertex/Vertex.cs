using System;
using UnityEngine;

public class Vertex : MonoBehaviour
{
    [SerializeField] private InventoryItem obolPiece2;
    private float timer = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            SoundManager.Instance.StopSound();
            SoundManager.Instance.PlaySound2D("ringBroken");
            char[] c = { 'V', 'E', 'R', 'T', 'E', 'X' };
            LetterManager.Instance.AddLetters(c, gameObject.transform.position);
            InventoryManager.Instance.AddInventoryItem(obolPiece2);
            QuestionManager.Instance.PopQuestionFromList(8);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 25)
        {
            timer = 0;
            SoundManager.Instance.PlaySoundPositional("vertexDrone", transform.position, 15, 30);
        }
    }
}
