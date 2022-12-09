using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserMove2 : MonoBehaviour
{
    public float speedX = 20;
    public float startX = 26;
    public float endX = -75;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speedX * Time.deltaTime,0,0);
        if (transform.position.x >= startX)
        {
            speedX = -speedX;
        }
        if (transform.position.x <= endX)
        {
            speedX = -speedX;
        }
    }
}
