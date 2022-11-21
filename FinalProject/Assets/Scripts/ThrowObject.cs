using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public static ThrowObject Instance;
    public GameObject[] items;

    public void throwingObject(string itemName) {
        foreach (GameObject item in items) {
            if (item.name == itemName) {
                Debug.Log(item.name);
                break;
            }
        }
    }
}
