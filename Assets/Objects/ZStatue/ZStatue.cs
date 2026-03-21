using UnityEngine;
using UnityEngine.EventSystems;

public class ZStatue : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private InteractibleDefiner definer;
    [SerializeField] private GameObject statueHead;
    private float timer = 0;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && definer.interactible && InventoryManager.Instance.HasItem("Obol"))
        {
            InventoryManager.Instance.RemoveInventoryItem("Obol");
            QuestionManager.Instance.PopQuestionFromList(9);
            statueHead.SetActive(false);
            LetterManager.Instance.AddLetter('Z', transform.position);
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = Random.Range(3f, 10f);
            SoundManager.Instance.PlaySoundPositional("zStandSounds", transform.position, 7, 25);
        }
        
    }
}
