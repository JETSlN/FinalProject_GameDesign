using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeLimit : MonoBehaviour
{
    [SerializeField]
    float timeRemaining = 100f;

    public TextMeshProUGUI timeText;

    void Update() {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0) {
            Debug.Log("Skill Issue be faster");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        timeText.text = timeRemaining.ToString("F2") + "  S";
    }

    public void setTimeRemaining(float newTime) {
        timeRemaining = newTime;
    }
}
