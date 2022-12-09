using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject message;

    void onTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            message.SetActive(true);
        }
    }

    void onTriggerExit(Collider other) {
        if (other.tag == "Player") {
            message.SetActive(false);
        }
    }
}
