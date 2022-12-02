using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector_timer : MonoBehaviour
{
    public bool first_time = true;
    public List<Boom> crystalbomb = new List<Boom>();


    private void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Player" && first_time){
            first_time = false;
            StartCoroutine(ExampleCoroutine(crystalbomb.Count));
        }   
    }

    
    IEnumerator ExampleCoroutine(int cb)
    {

    for(int i = 0; i < cb; i++){
        // crystalbomb[i].baboom();
        yield return new WaitForSeconds(0.5f);
    }




    }
}
