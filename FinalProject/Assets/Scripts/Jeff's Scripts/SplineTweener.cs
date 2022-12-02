using UnityEngine;
using Pixelplacement;

public class SplineTweener : MonoBehaviour
{
	public Spline mySpline;
	public Transform myObject;
	public float speed = 5f;
	public float start = 0f;
	void Awake ()
	{   
		Tween.Spline (mySpline, myObject, start, 1, true, speed - (speed * start), 0, Tween.EaseInOut, Tween.LoopType.None);

	}
}
