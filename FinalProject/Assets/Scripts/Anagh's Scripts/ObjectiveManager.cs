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
        "You are here to destroy the bird app servers. | Look for clues around the office. | There may be scraps of paper lying around. | Some of the office doors are locked. | Destroy them before the staff gets back.",
        "Find the manager's office. | Keep picking up objects that may be useful later on.",
        "Get to the server room. | The store room is also a valuable target. ",
        "Find a way to disable the security measures. | All security is routed through the server room.",
        "Get to the control room. | All security has been disabled | The control room has the master switch.",
        "Escape the office."
    };
    }

    public void incrementStoryIndex() {
        currentStoryIndex += 1;
    }

    public void incrementObjectiveIndex() {
        currentObjectIndex += 1;
    }

    public void setObjectiveIndex(int idx) {
        currentObjectIndex = idx;
    }

    public void ShowCurrentObjective() {
        string currentObjective = objectives[currentObjectIndex];
        lines = currentObjective.Split('|');

        StartCoroutine(Wait(4f, lines));
       
    }

    IEnumerator Wait(float time, string[] lines) {
        
        foreach(string line in lines) {
            Debug.Log(line);
            DialogController.instance.DisplayMessage(line);
            yield return new WaitForSeconds(time);
        }
        
    }
}
