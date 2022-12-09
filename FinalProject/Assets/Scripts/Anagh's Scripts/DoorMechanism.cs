using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanism : MonoBehaviour
{

    public Animator animator;
    public bool locked = false;
    private bool isOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Open() {
        animator.SetBool("hasBeenOpened", true);
        isOpen = true;

        // if (locked) {
        //     locked = false;
        //     return true;
        // } else {
        //     return false;
        // }
    }


    private void OnTriggerEnter(Collider other) {
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
                DialogController.instance.DisplayMessage("This door is not locked. You push the door and enter a room.");
                Open();
            // } 
        }
    }



    
}
