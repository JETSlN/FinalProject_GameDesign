using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingSpikess : MonoBehaviour
{
    public int dmg = 5;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player"){
            other.GetComponent<PlayerHealth>().takeDamage();
        }
        else if (other.gameObject.layer == 3){
            Destroy(gameObject);
        }
    }
}
