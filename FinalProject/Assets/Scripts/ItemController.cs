using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Video Link: https://www.youtube.com/watch?v=AoD_F1fSFFg
public class ItemController : MonoBehaviour
{
    public Item item;
    public PlayerHealth playerHP;
    public PlayerMovement playerStamina;

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
                //PlayerHealth.Instance.Heal(item.value);
                playerHP.Heal(item.value);
                break;
            case Item.ItemType.Stamina:
                playerStamina.staminaConsumable(item.value);
                break;
            case Item.ItemType.Projectile:
                Debug.Log("Throw Item");
                break;
        }

        RemoveItem();
    }
}
