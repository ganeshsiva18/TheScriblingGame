using UnityEngine;
using UnityEngine.EventSystems;

public class TabiGuyInteractionArea: MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TabiGameAI tabiGameAI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (tabiGameAI.interactible && (eventData.button == PointerEventData.InputButton.Right) && !tabiGameAI.isTabiGame)
        {
            if (tabiGameAI.timesPlayed == 0)
            {
                StartCoroutine(tabiGameAI.TabiGuyCutscene(3));
            }
            else
            {
                StartCoroutine(tabiGameAI.TabiGuyCutscene(1));
            }
        }
    }
}
