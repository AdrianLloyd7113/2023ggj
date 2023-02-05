using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalSplash : MonoBehaviour
{

    int time;
    
    void Start()
    {
        
    }

    void Update()
    {
        time++;
        if (time >= 100){
            PlayerPrefs.SetInt("level", 5);
            PlayerPrefs.SetInt("dec", 5);
            SceneManager.LoadScene("Room", LoadSceneMode.Single);
        }
    }
}
