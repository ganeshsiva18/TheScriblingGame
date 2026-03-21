using UnityEngine;
using UnityEngine.EventSystems;

public class ThreatAI: MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TabiGameController tabiGameAI;

    private bool canBeDestroyed = true;
    void Awake()
    {
        SoundManager.Instance.PlaySound2D("threatWarning");
        tabiGameAI = GameObject.FindGameObjectWithTag("Tabi Game Controller").GetComponent<TabiGameController>();
    }

    public void DisableButton()
    {
        SoundManager.Instance.StopSound();
        SoundManager.Instance.PlaySound2D("punch");
        canBeDestroyed = false;
    }

    public void DestroySelf()
    {
        tabiGameAI.SelfDestructThreat();
        Destroy(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (canBeDestroyed)
        {
            SoundManager.Instance.StopSound();
            tabiGameAI.DestroyThreat(gameObject);
        }
    }
}
