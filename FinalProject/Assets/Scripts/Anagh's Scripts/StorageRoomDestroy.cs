using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class StorageRoomDestroy : MonoBehaviour
{
    public Item lighter;

    public ParticleSystem particle;

    private void OnTriggerEnter(Collider other) {
        var interactButton = GameObject.FindGameObjectWithTag("InteractButton").GetComponent<Button>();
        TextMeshProUGUI buttonText =  interactButton.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        if (InventoryManager.Instance.HasItem(lighter)) {
            buttonText.SetText("Destroy Storage Room");
            interactButton.onClick.AddListener(DestroyStorage);

        }
        else {
            buttonText.SetText(("Tool Needed"));
            DialogController.instance.DisplayMessage("There are sensitive documents here. I should burn them down.");
        }
    }



    public void DestroyStorage() {
        particle.Play();
        DialogController.instance.DisplayMessage("You watch as the storage room burns to the ground.");
    }


    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            var interactButton = GameObject.FindGameObjectWithTag("InteractButton").GetComponent<Button>();
            TextMeshProUGUI buttonText =  interactButton.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
            buttonText.SetText("");
            interactButton.onClick.RemoveListener(DestroyStorage);
        }
    }
}
