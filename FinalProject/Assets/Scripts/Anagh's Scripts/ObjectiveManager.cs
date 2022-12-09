using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public int currentObjectIndex;
    public int currentStoryIndex;

    public string[] lines;
    public string[] storyline;

    public string[] objectives;



    private void Start() {
        currentObjectIndex = 0;
        objectives = new string[] {
        "Look for clues around the office. | There may be scraps of paper lying around. | Some of the office doors are unlocked.",
        "Find key to unlock server room operator's office",
        "Reach the server room",
        "Find a way to destroy the servers",
    };
    }

    private void incrementStoryIndex() {
        currentStoryIndex += 1;
    }

    private void incrementObjectiveIndex() {
        currentObjectIndex += 1;
    }

    public void ShowCurrentObjective() {
        string currentObjective = objectives[currentObjectIndex];
        lines = currentObjective.Split('|');

        StartCoroutine(Wait(6f, lines));
       
    }

    IEnumerator Wait(float time, string[] lines) {
        
        foreach(string line in lines) {
            Debug.Log(line);
            DialogController.instance.DisplayMessage(line);
            yield return new WaitForSeconds(time);
        }
        
    }
}
