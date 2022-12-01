using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart_Point : MonoBehaviour
{
    public GameObject item2;
    public GameObject camera; 
    // Update is called once per frame
    void Update()
    {
        float y = 0f;
        transform.position = new Vector3(item2.transform.position[0], item2.transform.position[1] + y, item2.transform.position[2]-1);
        //transform.rotation= (camera.transform.rotation[0],camera.transform.rotation[1],(camera.transform.rotation[2]/2f),1f);
        //transform.rotation = camera.transform.rotation;
        
    }
}
