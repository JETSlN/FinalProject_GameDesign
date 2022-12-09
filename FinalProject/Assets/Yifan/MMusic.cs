using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMusic : MonoBehaviour
{
    private void Awake() 
    {
        if (FindObjectsOfType<MMusic>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
