using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    [SerializeField]
    bool isOpened = false;
    [SerializeField]
    float closeY;
    [SerializeField]
    float openY;
    public GameObject button;
    public GameObject inventory;
    Vector3 pos;

    public void PressInventoryButton() {
        if (isOpened) {
            isOpened = false;
        } else {
            isOpened = true;
        }
    }

    void Update() {
        pos = button.transform.position;
        if (isOpened) {
            inventory.SetActive(true);
            pos.y = openY;
        } else {
            inventory.SetActive(false);
            pos.y = closeY;
        }
        button.transform.position = pos;
    }
}
