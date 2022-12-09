using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carthitmetrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag.Equals("Player"))
        {
            other.GetComponent<PlayerHealth>().takeDamage();
        }
    }
}
