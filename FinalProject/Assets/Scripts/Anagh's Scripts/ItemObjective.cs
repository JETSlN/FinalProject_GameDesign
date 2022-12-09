using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjective : MonoBehaviour
{
    public int idx = 0;

    public bool changeTimer = false;
    public float timerChange = 60f;

    public GameObject canvas;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            GameObject.FindGameObjectWithTag("ObjectivesButton").GetComponent<ObjectiveManager>().setObjectiveIndex(idx);
            if (changeTimer) {
                canvas.GetComponent<TimeLimit>().setTimeRemaining(timerChange);
            }
        }
    }
}
