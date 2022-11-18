using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KillSpike: MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        print("Hit");   
        if(other.gameObject.tag.Equals("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    /*
    private void OnCollisionEnter(Collision other) {
        print("Hit");   
        if(other.gameObject.tag.Equals("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    */
}
