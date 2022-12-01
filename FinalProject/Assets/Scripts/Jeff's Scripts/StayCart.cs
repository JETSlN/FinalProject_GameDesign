using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayCart : MonoBehaviour
{
    public GameObject cart;
    public float y = 3f;
    // Start is called before the first frame update
    public void trans(){
        transform.position = new Vector3(cart.transform.position[0], cart.transform.position[1] + y, cart.transform.position[2]-1);
    }
}
