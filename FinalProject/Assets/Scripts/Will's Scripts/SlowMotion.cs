using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float slowMotionMulti = 0.5f;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            Time.timeScale = slowMotionMulti;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            Time.timeScale = 1f;
        }
    }
}
