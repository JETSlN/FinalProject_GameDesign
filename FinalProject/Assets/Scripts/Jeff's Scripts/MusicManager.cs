using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private void Awake() 
    {
        if (FindObjectsOfType<MusicManager>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            //DontDestroyOnLoad(this.gameObject);
        }
    }
}
