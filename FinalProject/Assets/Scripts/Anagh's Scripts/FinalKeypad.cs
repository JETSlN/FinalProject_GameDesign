using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKeypad : MonoBehaviour
{
    public GameObject keypad;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            keypad.GetComponent<Keypad>().setIsForDoor(false);
            keypad.GetComponent<Keypad>().setAnswer("7437");
            keypad.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        
    }
}
