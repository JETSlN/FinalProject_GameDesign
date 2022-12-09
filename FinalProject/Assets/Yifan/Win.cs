using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public void Retry(){
        SceneManager.LoadScene("Tutorial");
    }
    
    public void MainM(){
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
