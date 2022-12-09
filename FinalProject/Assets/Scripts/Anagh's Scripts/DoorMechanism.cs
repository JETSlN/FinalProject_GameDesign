using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DoorMechanism : MonoBehaviour
{

    public Animator animator;
    public bool locked = false;
    private bool isOpen = false;

    public bool isKeypad = false;

    public Item key;

    public GameObject keypad;

    // public Button interactButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Open() {
        animator.SetBool("hasBeenOpened", true);
        locked = false;
        isOpen = true;

        // if (locked) {
        //     locked = false;
        //     return true;
        // } else {
        //     return false;
        // }
    }


    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player" && !isOpen) {
            // if (key != null && locked) {
            //     if (InventoryManager.instance.HasItem(key)) {
            //         DialogController.instance.DisplayMessage("The door opens as the key crumbles into a pile of rust.");
            //         InventoryManager.instance.RemoveItem(key);
            //         Open();
            //     }
            //     else {
            //         DialogController.instance.DisplayMessage("The door is locked. There must be a key around somewhere.");
            //     }
            // } else {
                // DialogController.instance.DisplayMessage("This door is not locked. You push the door and enter a room.");
                // Open();
            // } 


            // Attempt at creating an interactible UI
            var interactButton = GameObject.FindGameObjectWithTag("InteractButton").GetComponent<Button>();
            TextMeshProUGUI buttonText =  interactButton.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
            if (isKeypad) {
                keypad.SetActive(true);
            }
            else {
                if (locked) {
                    if (InventoryManager.Instance.HasItem(key)) {
                        buttonText.SetText("Unlock Door");
                        interactButton.onClick.AddListener(Open);
                    }
                    else {
                        buttonText.SetText("Key Needed");
                    }
                }
                else {
                    if (!isOpen) {
                        buttonText.SetText("Open Door");
                        interactButton.onClick.AddListener(Open);
                    }
                    
                }
            }
           
            

            }
        }

        private void OnTriggerExit(Collider other) {
            if (other.gameObject.tag == "Player") {
                var interactButton = GameObject.FindGameObjectWithTag("InteractButton").GetComponent<Button>();
                TextMeshProUGUI buttonText =  interactButton.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
                buttonText.SetText("");
                interactButton.onClick.RemoveListener(Open);
            } 
        }
    



    
}
