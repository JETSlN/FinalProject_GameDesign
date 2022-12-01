using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitrock : MonoBehaviour
{
    public char direction;
    public PlayerMovement player;
    public PlayerHealth health;
    private void OnTriggerEnter(Collider other) {
    
        if (other.gameObject.tag == "Minecart") {

            if(direction == player.directionCart || player.directionCart == 'N'){

                health.takeDamage();
            }
        }
    }
}
