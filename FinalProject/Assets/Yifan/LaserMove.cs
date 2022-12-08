using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    public float speedZ = -5;
    public float startZ = 92;
    public float endZ = 160;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, speedZ * Time.deltaTime);
        if (transform.position.z <= startZ)
        {
            speedZ = -speedZ;
        }
        if (transform.position.z >= endZ)
        {
            speedZ = -speedZ;
        }
    }
}
