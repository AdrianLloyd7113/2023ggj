using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    
    public GameObject text;

    void Start()
    {
        text = GameObject.Find("MainText");

        if (PlayerPrefs.GetInt("dec") == 1){
            text.GetComponent<Text>().text = "You awoke...\nEnding 1/4";
        }else if (PlayerPrefs.GetInt("dec") == 2){
            text.GetComponent<Text>().text = "You did not wake up...\nEnding 2/4";
        }else if (PlayerPrefs.GetInt("dec") == 3){
            text.GetComponent<Text>().text = "You remain in the tree...\nEnding 3/4";
        }else if (PlayerPrefs.GetInt("dec") == 4){
            text.GetComponent<Text>().text = "You are infected...\nEnding 4/4";
        }

    }

    void Update()
    {
        
    }
}
