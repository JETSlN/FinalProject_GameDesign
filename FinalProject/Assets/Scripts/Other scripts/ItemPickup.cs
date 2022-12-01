using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;

    void Pickup()
    {
        if (InventoryManager.Instance.capacity < InventoryManager.Instance.maxCapacity) {
            InventoryManager.Instance.Add(Item);
            InventoryManager.Instance.ListItems();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            Pickup();
        }
    }
}
