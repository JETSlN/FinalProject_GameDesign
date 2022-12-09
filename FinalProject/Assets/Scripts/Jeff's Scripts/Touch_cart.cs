using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_cart : MonoBehaviour
{
    public Transform cartyz; 
    public bool first_time = true;
    public GameObject player;
    public bool collided = false; 
    public SplineTrigger splineit; 
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && first_time){
            collided = true;
            player.GetComponent<PlayerMovement>().cartitup();
            first_time = false;
            splineit.call();
        }   
    }
    private void Update() {
          if(collided == true){
            
            player.GetComponent<StayCart>().trans();
            
          }

    }
}
