using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("Tutorial");
    }
    
    public void LevelSelect(){
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
