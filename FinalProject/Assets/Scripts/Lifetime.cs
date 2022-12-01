using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float lifespan = 2f;

    void Start()
    {
        Destroy(gameObject,lifespan);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && gameObject.tag == "PlayerProjectile") {
            Destroy(gameObject);
        }
        if (other.tag != "Enemy" && gameObject.tag == "EnemyProjectile") {
            Destroy(gameObject);
        }
    }
}
