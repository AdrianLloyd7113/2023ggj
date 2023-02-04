using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Sprite player;
    public double speed;
    public double health;
    public double strength;
    public double gravity;

    double xD;
    double yD;

    bool canJump;
    bool gRequired;
    double pull;
    
    void Start()
    {
        canJump = true;
    }

    void Update()
    {

        // Player movement control

        if (Input.GetKey("A")){
            xD = -speed;
        } else if (Input.GetKey("D")){
            xD = speed;
        }

        if (Input.GetKey("Space") && canJump){
            canjump = false;
            gRequired = true;
            pull = 5;
        }

        //Player combat



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
