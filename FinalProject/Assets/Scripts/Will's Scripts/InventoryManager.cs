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

    public int currItemIndex = -1; 

    public ItemController[] InventoryItems;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
        currItemIndex += 1;
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        // Print items before
        foreach(Transform item in ItemContent) {
            Debug.Log(item);
        }


        //clean items
        foreach (Transform item in ItemContent)
        {
            // Delete old ItemSlot clones from inventory
            Destroy(item.gameObject);
        }
        // Now ItemContent is cleaned
        // Debug.Log(ItemContent);
        // foreach(Transform item in ItemContent) {
        //     Debug.Log(item);
        // }


        // Print items
        Debug.Log(Items);


        foreach (var item in Items){
            // Create new game objects with InventoryItem (ItemSlot) as the prefab
            //  ItemContent as the parent. Where is the item though? 
            GameObject obj = Instantiate(InventoryItem, ItemContent);

            // obj.ItemController.Item = item;
            obj.GetComponent<ItemController>().item = item;



            //var itemName = obj.transform.Find("Item/ItemName").GetComponent<Text>();

            // Set icons for inventory
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            itemIcon.sprite = item.icon;
            //itemName.text = item.itemName;
        }

        // SetInventoryItems();
    }

    void Update()
    {
        capacity = Items.Count;
    }

    public bool HasItem(Item item) {
        return Items.Contains(item);
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
