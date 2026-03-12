using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Anvil : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private InteractibleDefiner definer;
    [SerializeField] private GameObject anvilGameMenu;
    [SerializeField] private Image swordSprite;
    [SerializeField] private Sprite[] swords;
    private int count = 0;
    private float clickTimer = 0;
    private int spriteIndex = 0;
    private bool swordForged = false;

    void Update()
    {
        if (anvilGameMenu.activeSelf)
        {
            clickTimer += Time.deltaTime;
            if (clickTimer > 0.75f && count >= 0)
            {
                clickTimer = 0;
                count -= 1;
            }
            if (count > 5)
            {
                ChangeSwordSprite();
                count = 0;
            }

        }
    }

    private void OpenAnvilMenu()
    {
        anvilGameMenu.SetActive(true);
        GameManager.Instance.canMove = false;
    }

    private void SwordFinishAnimation()
    {
        anvilGameMenu.GetComponent<Animator>().SetTrigger("swordForged");
    }

    public void SwordClick()
    {
        clickTimer = 0;
        count++;
    }

    private void ChangeSwordSprite()
    {
        swordSprite.sprite = swords[spriteIndex];
        if (spriteIndex == 4)
        {
            SwordFinishAnimation();
            swordForged = true;
        }
        spriteIndex++;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && definer.interactible && !swordForged)
        {
            OpenAnvilMenu();
        }
    }

}
