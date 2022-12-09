using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void PlayLevelTutotial(){
        SceneManager.MoveGameObjectToScene(GameObject.Find("Music"), SceneManager.GetActiveScene());
        SceneManager.LoadScene("Tutorial");
    }
    
    public void PlayLevel1(){
        SceneManager.MoveGameObjectToScene(GameObject.Find("Music"), SceneManager.GetActiveScene());
        SceneManager.LoadScene("Level 1");
    }

    public void PlayLevel2(){
        SceneManager.MoveGameObjectToScene(GameObject.Find("Music"), SceneManager.GetActiveScene());
        SceneManager.LoadScene("Level 2");
    }
    
    public void PlayLevel3(){
        SceneManager.MoveGameObjectToScene(GameObject.Find("Music"), SceneManager.GetActiveScene());
        SceneManager.LoadScene("Level 3");
    }
    
    public void PlayLevel4(){
        SceneManager.MoveGameObjectToScene(GameObject.Find("Music"), SceneManager.GetActiveScene());
        SceneManager.LoadScene("Level 4");
    }

    public void PlayLevel5(){
        SceneManager.MoveGameObjectToScene(GameObject.Find("Music"), SceneManager.GetActiveScene());
        SceneManager.LoadScene("Level 5");
    }
    public void Back(){
        SceneManager.LoadScene("Menu");
    }
}
