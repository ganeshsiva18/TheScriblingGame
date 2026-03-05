using UnityEngine;
using UnityEngine.EventSystems;

public class DummyInteractCollider: MonoBehaviour, IPointerDownHandler
{
    [SerializeField] DummyAI dummyAI;
    [SerializeField] private InteractibleDefiner definer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && definer.interactible)
        {
            dummyAI.Punch(true);
        }
    }
}
