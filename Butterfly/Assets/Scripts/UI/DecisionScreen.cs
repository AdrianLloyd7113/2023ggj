using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DecisionScreen : MonoBehaviour
{

    public GameObject btn1;
    public GameObject btn2;
    Button a;
    Button b;

    void Start()
    {
        a = btn1.GetComponent<Button>();
        b = btn2.GetComponent<Button>();

        a.onClick.AddListener(TaskOnClickA);
        b.onClick.AddListener(TaskOnClickB);
    }

    void TaskOnClickA()
    {
        //room one options
        PlayerPrefs.SetInt("dec", PlayerPrefs.GetInt("dec") + 1);
        SceneManager.LoadScene("Room", LoadSceneMode.Single);
    }

    void TaskOnClickB()
    {
        //room two options
        PlayerPrefs.SetInt("dec", PlayerPrefs.GetInt("dec") + 2);
        SceneManager.LoadScene("Room", LoadSceneMode.Single);
    }
}
