using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCart : MonoBehaviour
{
    public Touch_cart cart;
    public PlayerMovement player;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Minecart") {
            print("hello");
            cart.collided = false;
            player.cartitup();
        }
    }
}
