using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadOB;

    public GameObject door;

    // public Text textOB;

    public TextMeshProUGUI inputField;

    // public TMP_InputField inputField;
    public string answer = "517504";
    // public GameObject hud;
    // public GameObject inv;

    //  Audio




    public void Number(int number) {
        inputField.text += number.ToString();
        Debug.Log(number);
        // Audio plays
    }

    public void Execute() {
        if (inputField.text == answer) {
            // Correct audio plays

            inputField.text = "Right";
            door.GetComponent<DoorMechanism>().Open();
        }
        else {
            // Wrong audio plays
            inputField.text = "Wrong";

        }
    }

    public void Clear() {
        inputField.text = "";
    }

    public void Exit() {
        keypadOB.SetActive(false);
    }

    private void Update() {
        if (inputField.text == "Right") {
            // Door animation
        }
    }




    






}
