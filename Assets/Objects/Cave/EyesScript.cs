using UnityEngine;
using UnityEngine.EventSystems;

public class EyesScript : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private InteractibleDefiner definer;
    [SerializeField] private InventoryItem fishItem;
    [SerializeField] private InventoryItem obolPiece;
    [SerializeField] private DialogueText starterDialogue;
    [SerializeField] private GameObject eyes;
    private bool hasBeenTalked;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && definer.interactible)
        {
            if (!InventoryManager.Instance.HasItem(fishItem)|| !hasBeenTalked)
            {
                hasBeenTalked = true;
                DialogueManager.Instance.DoDialogue(starterDialogue);
            }
            else
            {
                InventoryManager.Instance.RemoveInventoryItem(fishItem);
                InventoryManager.Instance.AddInventoryItem(obolPiece);
                QuestionManager.Instance.PopQuestionFromList(4);
                Destroy(eyes);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
