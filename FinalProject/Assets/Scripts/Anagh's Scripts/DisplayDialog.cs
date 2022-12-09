using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDialog : MonoBehaviour
{

    public string message;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            string[] lines = message.Split('|');
            StartCoroutine(Wait(4f, lines));
        }
        
    }
    IEnumerator Wait(float time, string[] lines) {
        
        foreach(string line in lines) {
            Debug.Log(line);
            DialogController.instance.DisplayMessage(line);
            yield return new WaitForSeconds(time);
        }
        
    }
}
