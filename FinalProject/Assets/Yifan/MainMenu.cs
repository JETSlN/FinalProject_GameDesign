using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.MoveGameObjectToScene(GameObject.Find("Music"), SceneManager.GetActiveScene());
        SceneManager.LoadScene("Tutorial");
    }
    
    public void LevelSelect(){
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
