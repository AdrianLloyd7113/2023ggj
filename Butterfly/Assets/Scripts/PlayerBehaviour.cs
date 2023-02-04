using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Sprite player;
    public int speed;
    public int health;
    public int strength;
    public int gravity;

    int xD;
    int yD;

    bool gRequired;
    int pull;
    
    void Start()
    {
        
    }

    void Update()
    {

        // Player control
        if (Input.GetKey("A")){
            xD = -speed;
        } else if (Input.GetKey("D")){
            xD = speed;
        }

        if (Input.GetKey("Space")){
            pull = 5;
        }

        // Gravity

        if (gRequired && pull > -gravity){
            pull -= 0.1;
        }

        transform.position += new Vector3(xD, yD, 0) * Time.deltaTime;
    }

    void grounded(){
        pull = 0;
        gRequired = false;
    }
}
