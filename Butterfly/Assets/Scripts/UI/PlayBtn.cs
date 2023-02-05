using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayBtn : MonoBehaviour
{
    Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("got here");
        PlayerPrefs.SetString("style", "regular");
        PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene("Room", LoadSceneMode.Single);
    }
}
