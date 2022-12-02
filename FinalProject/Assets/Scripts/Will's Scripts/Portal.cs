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
            //Debug.Log("teleport");
            CharacterController cc = player.GetComponent<CharacterController>();
            cc.enabled = !cc.enabled;
            player.transform.position = otherPortal.transform.position + offset;
            cc.enabled = !cc.enabled;
        }
    }
}
