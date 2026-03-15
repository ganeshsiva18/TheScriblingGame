using UnityEngine;
using UnityEngine.EventSystems;

public class ThreatAI: MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TabiGameController tabiGameAI;

    private bool canBeDestroyed = true;
    void Awake()
    {
        tabiGameAI = GameObject.FindGameObjectWithTag("Tabi Game Controller").GetComponent<TabiGameController>();
    }

    public void disableButton()
    {
        canBeDestroyed = false;
    }

    public void destroySelf()
    {
        tabiGameAI.SelfDestructThreat();
        Destroy(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (canBeDestroyed)
        {
            tabiGameAI.DestroyThreat(gameObject);
        }
    }
}
