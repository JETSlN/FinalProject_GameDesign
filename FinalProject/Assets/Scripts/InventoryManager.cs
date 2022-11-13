using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Video Link: https://www.youtube.com/watch?v=AoD_F1fSFFg
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;
    public float capacity;
    public float maxCapacity;

    public ItemController[] InventoryItems;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        //clean items
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in Items){
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            //var itemName = obj.transform.Find("Item/ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            //itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
        SetInventoryItems();
    }

    void Update()
    {
        capacity = Items.Count;
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<ItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }
}
