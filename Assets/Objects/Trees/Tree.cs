using UnityEngine;
using UnityEngine.EventSystems;

public class Tree : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private InteractibleDefiner definer;
    [SerializeField] private Animator animator;
    [SerializeField] private InventoryItem item;
    [SerializeField] private GameObject monkey;
    [SerializeField] private bool isGolden;
    [SerializeField] private bool isMonkey;
    private float timer = 0;
    private float randomTime = 1;

    void Update()
    {
        if (isMonkey)
        {
            timer += Time.deltaTime;
            if (randomTime > timer)
            {
                timer = 0;
                animator.SetTrigger("shake");
                randomTime = Random.Range(1f, 5f);
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            animator.SetTrigger("shake");
            if (isGolden)
            {
                InventoryManager.Instance.AddInventoryItem(item);
                isGolden = false;
            } else if (isMonkey)
            {
                Instantiate(monkey, transform.position, Quaternion.identity);
                char[] chars = { 'M', 'O', 'N', 'K', 'E', 'Y' };
                LetterManager.Instance.AddLetters(chars, transform.position);
                isMonkey = false;
            }
        }
    }
}
