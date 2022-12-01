using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_cart : MonoBehaviour
{
    public bool first_time = true;
    public GameObject player;
    public bool collided = false; 
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && first_time){
            collided = true;
            player.GetComponent<PlayerMovement>().cartitup();
            first_time = false;
        }   
    }
    private void Update() {
          if(collided == true){
            player.GetComponent<StayCart>().trans();
          }

    }
}
