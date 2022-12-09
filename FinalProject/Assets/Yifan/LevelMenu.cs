using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void PlayLevelTutotial(){
        SceneManager.LoadScene("Tutorial");
    }
    
    public void PlayLevel1(){
        SceneManager.LoadScene("Level 1");
    }

    public void PlayLevel2(){
        SceneManager.LoadScene("Level__");
    }
    
    public void PlayLevel3(){
        SceneManager.LoadScene("0");
    }
    
    public void PlayLevel4(){
        SceneManager.LoadScene("Level X");
    }

    public void PlayLevel5(){
        SceneManager.LoadScene("Office2");
    }
}
