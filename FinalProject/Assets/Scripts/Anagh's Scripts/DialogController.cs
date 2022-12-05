using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{

    TextMeshProUGUI mainText;
    public GameObject canvas;

    public bool isWorking;

    public static DialogController instance;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        mainText = canvas.transform.Find("MainText").GetComponent<TextMeshProUGUI>();


    }


    public void SetText(string text) {
        mainText.SetText(text);
    }

    public void DisplayMessage(string message) {
        canvas.SetActive(true);
        SetText(message);
        StartCoroutine(WaitAndClose(2f));
    }

    IEnumerator WaitAndClose(float time) {
        yield return new WaitForSeconds(time);
        canvas.SetActive(false);
    }
}
