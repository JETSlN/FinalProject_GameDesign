using UnityEngine;
using Pixelplacement;

public class SplineTweener : MonoBehaviour
{
	public Spline mySpline;
	public Transform myObject;
	public float speed = 5f;

	void Awake ()
	{   
		Tween.Spline (mySpline, myObject, 0, 1, true, speed, 0, Tween.EaseInOut, Tween.LoopType.None);

	}
}
