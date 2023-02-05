using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{

    public GameObject target;
    public GameObject lAmmo;
    public GameObject rAmmo;

    public float speed;
    public float health;
    public float strength;
    public float gravity;

    public int decisionTimer;

    float xD;
    float yD;

    bool canJump;
    bool gRequired;
    float pull;
    
    public Sprite[] options = new Sprite[10];

    void Start()
    {
        target = GameObject.Find("character");

        canJump = true;
        gRequired = true;
        pull = 1f;
    }

    void Update()
    {

        if (health <= 0){
            die();
        }

        // Decision

        if (decisionTimer == 0){
            System.Random r = new System.Random();
            int i = r.Next(5);
            if (i == 0 && canJump){
                jump();
            } else if (i == 1){
                if (transform.position.x >= -8.14){
                    xD = -speed;
                }else{
                    xD = 0;
                }
            } else if (i == 2){
                if (transform.position.x <= 8){
                    xD = speed;
                }else{
                    xD = 0;
                }
            } else if (i == 3){
                xD = 0;
            } else if (i == 4){
                if (transform.position.x > target.transform.position.x){
                    shoot(0);
                } else {
                    shoot(1);
                }
            }

            decisionTimer = 10;
        } else {
            decisionTimer--;
        }

        // Gravity

        if (gRequired && pull > -gravity){
            pull -= 0.2f;
        }

        transform.position += new Vector3(xD, pull, 0) * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "ground"){
            grounded();
        } else if (col.gameObject.tag == "Player"){
            col.gameObject.GetComponent<PlayerBehaviour>().health -= 10;
        } else if (col.gameObject.tag == "leftproj" || col.gameObject.tag == "rightproj"){
            Destroy(col.gameObject);
            health -= 10;
        }
    }

    void grounded(){
        pull = 0;
        canJump = true;
        gRequired = false;
    }

    void jump(){
        canJump = false;
        gRequired = true;
        pull = 10f;
    }

    void shoot(int dir){
        if (dir == 0){
            Instantiate(lAmmo, new Vector3(transform.position.x - 1.5f, transform.position.y, 0), Quaternion.identity);
        }else{
            Instantiate(rAmmo, new Vector3(transform.position.x + 1.5f, transform.position.y, 0), Quaternion.identity);
        }
    }

    void die(){
        Destroy(gameObject);
    }
}
