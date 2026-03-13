using UnityEngine;
using UnityEngine.EventSystems;

public class ZStatue : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private InteractibleDefiner definer;
    [SerializeField] private GameObject statueHead;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && definer.interactible && InventoryManager.Instance.HasItem("Obol"))
        {
            InventoryManager.Instance.RemoveInventoryItem("Obol");
            GameManager.Instance.ifObolClaimed = true;
            statueHead.SetActive(false);
            LetterManager.Instance.AddLetter('Z', transform.position);
        }
    }
}
