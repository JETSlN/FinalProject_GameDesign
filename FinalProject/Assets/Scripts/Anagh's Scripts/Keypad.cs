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

    public ParticleSystem p1;
    public ParticleSystem p2;
    public ParticleSystem p3;
    public ParticleSystem p4;
    public ParticleSystem p5;
    public ParticleSystem p6;
    public ParticleSystem p7;
    public ParticleSystem p8;
    public ParticleSystem p9;
    public ParticleSystem p10;
    public ParticleSystem p11;
    public ParticleSystem p12;
    public ParticleSystem p13;
    public ParticleSystem p14;
    public ParticleSystem p15;

    public GameObject emergencyDoor;

    public bool isForDoor = true;

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

    public void setAnswer(string newAns) {
        answer = newAns;
    }

    public void setIsForDoor(bool newBool) {
        isForDoor = newBool;
    }

    public void Execute() {
        if (inputField.text == answer) {
            // Correct audio plays

            inputField.text = "Right";
            if (isForDoor) {
                door.GetComponent<DoorMechanism>().Open();
            }
            else {
                // End game screen
                p1.Play();
                p2.Play();
                p3.Play();
                p4.Play();
                p5.Play();
                p6.Play();
                p7.Play();
                p8.Play();
                p9.Play();
                p10.Play();
                p11.Play();
                p12.Play();
                p13.Play();
                p14.Play();
                p15.Play();

                DialogController.instance.DisplayMessage("Mission Complete. Find a way to escape the office.");
                
                // Unlock emergency exit
                emergencyDoor.GetComponent<DoorMechanism>().setLocked(false);
            }
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
