using System.Collections.Generic;
using UnityEngine;

public class InventoryManager: MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject newItemAlert;

    public static InventoryManager Instance;
    private List<InventoryItem> inventoryItems = new List<InventoryItem>();
    private List<GameObject> inventoryItemsVisual = new List<GameObject>();
    private bool inventoryOpened;
    private GameObject newItemAlertInstance;
    void Awake()
    {
        if (Instance != null) 
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }

    // Button trigger for either opening or closing the inventory
    public void InventoryTriggered()
    {
        if (!inventoryOpened)
        {
            inventoryOpened = true;
            OpenInventory();
        } else
        {
            inventoryOpened = false;
            CloseInventory();
        }
    }

    // Opens the visual inventory
    private void OpenInventory()
    {
        for (int i = 0; i < inventoryItems.Count; i++) 
        {
            InstantiateInventoryItem(inventoryItems[i], i);
        }
        animator.SetBool("backpackOpen", true);
        if (newItemAlertInstance != null)
        {
            Destroy(newItemAlertInstance);
        }
    }

    // Closes the visual inventory
    private void CloseInventory()
    {
        for (int i = inventoryItemsVisual.Count-1; i >= 0; i--)
        {
            Destroy(inventoryItemsVisual[i]);
        }
        animator.SetBool("backpackOpen", false);
    }

    // Adds an item into the inventory
    public void AddInventoryItem(InventoryItem item)
    {
        inventoryItems.Add(item);
        if (newItemAlertInstance == null)
        {
            newItemAlertInstance = Instantiate(newItemAlert);
            newItemAlertInstance.transform.SetParent(gameObject.transform);

            newItemAlertInstance.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y+1.2f);
            newItemAlertInstance.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    // Removes an item from the inventory
    public void RemoveInventoryItem(InventoryItem item)
    {
        inventoryItems.Remove(item);
    }

    // Reveals and positions an inventory item
    private void InstantiateInventoryItem(InventoryItem item, int position)
    {
        GameObject visualItem = new GameObject(item.itemName);
        visualItem.transform.parent = gameObject.transform;

        RectTransform rectTransform = visualItem.AddComponent<RectTransform>();
        UnityEngine.UI.Image image = visualItem.AddComponent<UnityEngine.UI.Image>();

        image.sprite = item.itemSprite;
        image.transform.localScale = new Vector3(1, 1, 1);
        image.raycastTarget = false;
        rectTransform.anchoredPosition = new Vector2(gameObject.transform.position.x+150, gameObject.transform.position.y);
        rectTransform.anchoredPosition += new Vector2(position*110, 0);
        inventoryItemsVisual.Add(visualItem);
    }
}
