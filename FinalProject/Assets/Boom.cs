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
    void baboom(){
        Tween.Position (transform, transform.position, new Vector3 (transform.position[0]+x,transform.position[1]+y,transform.position[2]+z), 0.5f, 0);
    }
}
