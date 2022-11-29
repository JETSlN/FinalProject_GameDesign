using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_cart : MonoBehaviour
{

    public GameObject player;
    public bool collided = false; 
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player"){
            collided = true;
            player.GetComponent<PlayerMovement>().cartitup();
        }   
    }
    private void Update() {
          if(collided == true){
            
            player.GetComponent<StayCart>().trans();
          }

    }
}
