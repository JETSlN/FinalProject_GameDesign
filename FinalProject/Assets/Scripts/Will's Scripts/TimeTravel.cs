using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    public GameObject player;
    public void TimeT()
    {
        CharacterController cc = player.GetComponent<CharacterController>();
        cc.enabled = !cc.enabled;
        Debug.Log(transform.position);
        if (transform.position.y > 300)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y-600, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y+600, transform.position.z);
        }
        Debug.Log(transform.position);
        cc.enabled = !cc.enabled;
    }
}
