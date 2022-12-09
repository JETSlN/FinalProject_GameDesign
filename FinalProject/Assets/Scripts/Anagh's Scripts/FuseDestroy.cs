using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseDestroy : MonoBehaviour
{

    public Item wrench;

    private void OnTriggerEnter(Collider other) {
        var interactButton = GameObject.FindGameObjectWithTag("InteractButton").GetComponent<Button>();
        TextMeshProUGUI buttonText =  interactButton.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        if (InventoryManager.Instance.HasItem(wrench)) {
            buttonText.SetText("Destroy Fusebox");
            interactButton.onClick.AddListener(DestroyFuse);

        }
        else {
            buttonText.SetText(("Tool Needed"));
            DialogController.instance.DisplayMessage("I need something to destroy this fusebox.");
        }
    }

    public void DestroyFuse() {
        // Spawn Sparks

        // Turn off the lights

        // Open Control Room Doors

        // Trigger sirens etc
        


    }


    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            var interactButton = GameObject.FindGameObjectWithTag("InteractButton").GetComponent<Button>();
            TextMeshProUGUI buttonText =  interactButton.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
            buttonText.SetText("");
            interactButton.onClick.RemoveListener(DestroyFuse);
        }
    }
}
