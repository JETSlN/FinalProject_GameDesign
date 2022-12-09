using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPickup : MonoBehaviour
{
    public string message = "";
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<ItemController>().item.message = message;
    }

}
