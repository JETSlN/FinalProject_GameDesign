using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Video Link: https://www.youtube.com/watch?v=AoD_F1fSFFg
public class ItemController : MonoBehaviour
{
    public Item item;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        switch(item.itemType)
        {
            case Item.ItemType.HP:
                PlayerHealth.Instance.Heal(item.value);
                break;
            case Item.ItemType.Stamina:
                PlayerMovement.Instance.staminaConsumable(item.value);
                break;
            case Item.ItemType.Projectile:
                ThrowObject.Instance.throwingObject(item.itemName);
                break;
        }

        RemoveItem();
    }
}
