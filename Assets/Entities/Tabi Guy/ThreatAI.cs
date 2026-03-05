using UnityEngine;
using UnityEngine.EventSystems;

public class ThreatAI: MonoBehaviour, IPointerClickHandler
{
    private bool canBeDestroyed = true;
    [SerializeField] private TabiGameController tabiGameAI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        tabiGameAI = GameObject.FindGameObjectWithTag("Tabi Game Controller").GetComponent<TabiGameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
