using UnityEngine;
using Pixelplacement;

public class SplineTweenerTrap : MonoBehaviour
{
	public Spline mySpline;
	public Transform myObject;
	public float speed = 5f;
	public float start = 0f;
	void Awake()
	{   
		Tween.Spline (mySpline, myObject, 0, 1, true, speed, start, Tween.EaseInOut, Tween.LoopType.PingPong);

	}
}
