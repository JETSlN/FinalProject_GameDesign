using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanic : MonoBehaviour
{

    public Animator animator;
    public GameObject navMeshObstacle;
    private LayerMask ItemMask;

    public bool locked = false;
    public bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        // Locking mechanic
    }

    public void Open() {
        animator.SetBool("hasBeenOpened", true);
        isOpen = true;
        navMeshObstacle.SetActive(false);
        

        // Locking code
    }

    public void Close() {
        animator.SetBool("hasBeenOpened", false);
        isOpen = false;
        navMeshObstacle.SetActive(true);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && !isOpen) {
            // Locking code
            Open();
        }
        // else if (other.gameObject.tag == "Player" && isOpen) {
        //     Close();
        // }
    }
}
