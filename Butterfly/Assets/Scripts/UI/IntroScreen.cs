using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScreen : MonoBehaviour
{

    int time;
    
    void Start()
    {
        
    }

    void Update()
    {
        time++;
        if (time >= 200){
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}
