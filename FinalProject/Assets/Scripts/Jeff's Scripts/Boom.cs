using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
public class Boom : MonoBehaviour
{
    
    public static int Damage = 5;
    public bool active = false;
    [SerializeField] ParticleSystem  explosion = null;
    public float x = 0;
    public float y = 0;
    public float z = 0;
    public char direction;
    public PlayerMovement player; 
    public PlayerHealth health;
    public AudioSource audioSource;
    public AudioClip explosionz;


    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "Player") {
            if(player.cart == false){
                health.takeDamage();
            }
            else if(direction == player.directionCart || player.directionCart == 'N'){

                health.takeDamage();
            }
        }
    }
    public void baboom(){
        explosion.Play();
        GetComponent<AudioSource>().PlayOneShot(explosionz);
        Tween.Position (transform, transform.position, new Vector3 (transform.position[0]+x,transform.position[1]+y,transform.position[2]+z), 0.1f, 0);
    }
}
