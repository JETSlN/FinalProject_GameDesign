using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector_timer : MonoBehaviour
{
    public bool first_time = true;
    public List<GameObject> crystalbomb = new List<GameObject>();


    private void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Player" && first_time){
            first_time = false;
            StartCoroutine(ExampleCoroutine());
        }   
    }

    
    IEnumerator ExampleCoroutine()
    {


        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.5f);


    }
}
