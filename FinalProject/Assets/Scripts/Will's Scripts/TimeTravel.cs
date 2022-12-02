using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    public void TimeT()
    {
        Debug.Log(transform.position);
        if (transform.position.y > 100)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y-100, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y+100, transform.position.z);
        }
        Debug.Log(transform.position);
    }
}
