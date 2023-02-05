using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public GameObject camera;
    public GameObject[] enemies;
    public GameObject enemy;
    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;
    public GameObject boss4;
    
    int level;

    void Start()
    {
        level = PlayerPrefs.GetInt("level");
        if (level == 0){
            level = 1;
            PlayerPrefs.SetInt("level", 1);
        }

        enemies = new GameObject[level];
        camera = GameObject.Find("MainCamera");

        if (level == 5){
            camera.GetComponent<Camera>().backgroundColor = Color.grey;

            int i = PlayerPrefs.GetInt("dec") - 2;
            
            if (i == 1){
                Instantiate(boss1, new Vector3(7.5f, -0.89f, 0), Quaternion.identity);
            }else if (i == 2){
                Instantiate(boss2, new Vector3(7.5f, -0.89f, 0), Quaternion.identity);
            }else if (i == 3){
                Instantiate(boss3, new Vector3(7.5f, -0.89f, 0), Quaternion.identity);
            }else if (i == 4){
                Instantiate(boss4, new Vector3(7.5f, -0.89f, 0), Quaternion.identity);
            }else{
                Instantiate(boss1, new Vector3(7.5f, -0.89f, 0), Quaternion.identity);
                PlayerPrefs.SetInt("dec", 1);
            }


        } else { 

            for (int i = 0; i < level; i++){
                GameObject instEnem = (GameObject) Instantiate(enemy, new Vector3((float)(7.5 - (float)level), -0.89f, 0), Quaternion.identity);
                enemies[i] = instEnem;
            }

        }
    }

    void Update()
    {
        
    }
    
}
