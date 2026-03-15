using UnityEngine;
using UnityEngine.EventSystems;

public class TabiGuyInteractionArea: MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TabiGameAI tabiGameAI;

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
