using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Sprite player;
    public float speed;
    public float health;
    public float strength;
    public float gravity;

    float xD;
    float yD;

    bool canJump;
    bool gRequired;
    float pull;
    
    void Start()
    {
        canJump = true;
        gRequired = true;
        pull = 1f;
    }

    void Update()
    {

        // Player movement control

        if (Input.GetKey(KeyCode.A)){
            xD = -speed;
        } else if (Input.GetKey(KeyCode.D)){
            xD = speed;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)){
            xD = 0;
        }

        if (Input.GetKey(KeyCode.Space) && canJump){
            Debug.Log("Got here");
            canJump = false;
            gRequired = true;
            pull = 10f;
        }

        //Player combat



        // Gravity

        if (gRequired && pull > -gravity){
            pull -= 0.2f;
        }

        transform.position += new Vector3(xD, pull, 0) * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "ground"){
            grounded();
        }
    }

    void grounded(){
        pull = 0;
        canJump = true;
        gRequired = false;
    }
}
