using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
public class SplineTrigger : MonoBehaviour
{
	public Spline mySpline;
	public Transform myObject;
	public float speed = 5f;
	public float start = 0f;
	public AudioSource audioSource;
	public AudioClip cartyit;

	public void call()
	{   
		GetComponent<AudioSource>().PlayOneShot(cartyit);

		Tween.Spline (mySpline, myObject, start, 1, true, speed - (speed * start), 0, Tween.EaseInOut, Tween.LoopType.None);

	}
}
