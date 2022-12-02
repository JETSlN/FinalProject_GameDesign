using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform otherPortal;
    public GameObject player;
    public Vector3 offset;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){
            player.transform.position = otherPortal.transform.position;
        }
    }
}
