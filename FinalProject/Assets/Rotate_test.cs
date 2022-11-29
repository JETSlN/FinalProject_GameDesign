using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class Rotate_test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Tween.Rotation(transform, new Vector3 (0,0,30), 1, 1, Tween.EaseInOutStrong);
    }

}
