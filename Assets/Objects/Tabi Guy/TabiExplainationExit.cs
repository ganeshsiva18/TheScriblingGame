using UnityEngine;
using UnityEngine.EventSystems;

public class TabiExplainationExit: MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject explanation;
    private TabiGameAI tabiGameAI;
    public void OnPointerClick(PointerEventData eventData)
    {
        tabiGameAI.instructionsClosed = true;
        explanation.SetActive(false);
        Time.timeScale = 1f;
    }

    void Start()
    {
        tabiGameAI = GameObject.FindGameObjectWithTag("Tabi Guy").GetComponent<TabiGameAI>();
        Time.timeScale = 0f;
    }
}
